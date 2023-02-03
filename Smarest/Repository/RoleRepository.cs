using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smarest.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private UserManager<IdentityUser> _userManger;
        private RoleManager<IdentityRole> _roleManger;

        public RoleRepository(UserManager<IdentityUser> userManger, RoleManager<IdentityRole> roleManger)
        {
            _userManger = userManger;
            _roleManger = roleManger;
        }

        public async Task<UserManagerResponse> AddUserToRole(UserRolesViewModel userRolesViewModel)
        {
            var user = await _userManger.FindByIdAsync(userRolesViewModel.Id);
            try
            {
                await _userManger.AddToRoleAsync(user, userRolesViewModel.roles.FirstOrDefault());
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {
                    IsSuccess= false,
                    Message = "Added user to role fail ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Added user to guest ..."
            };
        }

        public async Task<List<Role>> GetRoles()
        {
            var roles =  await _roleManger.Roles.ToListAsync();
            var result = new List<Role>();
            foreach (var role in roles)
            {
                result.Add(new Role
                {
                    Id = role.Id,
                    Name = role.Name,
                    NormalizedName = role.NormalizedName,
                });
            }
            return result;
        }

        public async Task<List<Role>> GetUserRoles(string id)
        {
            var user = await _userManger.FindByIdAsync(id);
            var roles = await _userManger.GetRolesAsync(user);
            var result = new List<Role>();
            foreach (var role in roles)
            {
                result.Add(new Role
                {
                    Name = role
                });
            }
            return result;
        }

        public async Task<UserManagerResponse> RemoveUserFromRole(UserRolesViewModel userRolesViewModel)
        {
            var user = await _userManger.FindByIdAsync(userRolesViewModel.Id);
            try
            {
                await _userManger.RemoveFromRolesAsync(user, userRolesViewModel.roles);
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Removed user to role fail ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Removed user to guest ..."
            };
        }
    }
}
