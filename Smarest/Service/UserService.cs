using EllipticCurve.Utils;
using Google.Apis.Auth;
using Google.Apis.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Smarest.Data;
using Smarest.Model;
using Smarest.Service;
using Smarest.Service.IService;
using Smarest.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Smarest.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;
        private IMailService _mailService;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<IdentityUser> _signInManager;
        private ApplicationDbContext _context;
        

        public UserService(ApplicationDbContext context,RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration configuration, IMailService mailService) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _mailService = mailService; 
            _context = context;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var identityUser = new User
            {
                Email = model.Email,
                UserName = model.Email,
                CreatedDate = DateTime.Now,

            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);
            //var addUserToGuestRole = 

            if (result.Succeeded)
            {
                var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"{_configuration["AppUrl"]}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";

                await _mailService.SendEmailAsync(identityUser.Email, "Confirm your email", $"<h1>Welcome to Auth Demo</h1>" +
                    $"<p>Please confirm your email by <a href='{url}'>Clicking here</a></p>");


                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }



            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if(!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            var claims = new List<Claim>           
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userClaims);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));



            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,           
                expires: DateTime.Now.AddHours(24),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(6),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string refreshTokenAsString = new JwtSecurityTokenHandler().WriteToken(refreshToken);

            var userToUpdate = await _context.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

            userToUpdate.RefreshToken = refreshTokenAsString;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return new UserManagerResponse
                {
                    Message = "Some thing wrong",
                    IsSuccess = false,
                    ExpireDate = token.ValidTo,
                    RefeshToken = refreshTokenAsString,
                };
            }

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                RefeshToken = refreshTokenAsString,
            };
        }

        public async Task<List<User>> GetUsersInRole()
        {
            var identityUsers = await _userManager.GetUsersInRoleAsync("Guest");
            var userList = identityUsers.ToList();
            var users = new List<User>();

            userList.ForEach(u => users.Add(_context.Users.SingleOrDefault(user => user.Id == u.Id)));         
            return users;
        }




        public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";

            await _mailService.SendEmailAsync(email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password <a href='{url}'>Click here</a></p>");

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!"
            };
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        {
          
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if(model.NewPassword != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }
        public async  Task<UserManagerResponse> GenerateRefreshToken(UserRefreshTokenViewModel model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.RefreshToken == model.RefreshToken);
            if(user == null)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Refresh Token Isvalid",
                };
            }
            else
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

                var claims = new List<Claim>
                {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                };
                var userClaims = await _userManager.GetClaimsAsync(user);
                var userRoles = await _userManager.GetRolesAsync(user);
                claims.AddRange(userClaims);

                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                    var role = await _roleManager.FindByNameAsync(userRole);
                    if (role != null)
                    {
                        var roleClaims = await _roleManager.GetClaimsAsync(role);
                        foreach (Claim roleClaim in roleClaims)
                        {
                            claims.Add(roleClaim);
                        }
                    }
                }

                var token = new JwtSecurityToken(
                    issuer: _configuration["AuthSettings:Issuer"],
                    audience: _configuration["AuthSettings:Audience"],
                    claims: claims,
                    expires: DateTime.Now,
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);


                return new UserManagerResponse
                {
                    RefeshToken = model.RefreshToken,
                    IsSuccess = true,
                    Message = tokenAsString,
                };
            }      
        }

        public async Task<UserManagerResponse> LoginGoogle(CredentialResponse credentialResponse)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            var configCredentialResponse = credentialResponse.credential.Substring(1);
            configCredentialResponse = configCredentialResponse.Substring(0, configCredentialResponse.Length - 1);

            credentialResponse.credential = configCredentialResponse;
            
            var jwtToken = jwtHandler.ReadJwtToken(credentialResponse.credential);
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                user = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    CreatedDate = DateTime.Now,
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, Utils.Role.Guest);
                   
                }
            }

            var claims = new List<Claim>
            {
                new Claim("Email", email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userClaims);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(6),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string refreshTokenAsString = new JwtSecurityTokenHandler().WriteToken(refreshToken);


            var userToUpdate = await _context.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

            userToUpdate.RefreshToken = refreshTokenAsString;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return new UserManagerResponse
                {
                    Message = "Some thing wrong",
                    IsSuccess = false,
                    ExpireDate = token.ValidTo,
                    RefeshToken = refreshTokenAsString,
                };
            }

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                RefeshToken = refreshTokenAsString,
            };
        }
    }
}
