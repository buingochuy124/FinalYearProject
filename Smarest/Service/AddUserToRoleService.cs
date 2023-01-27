using Microsoft.AspNetCore.Identity;
using Smarest.Model;
using Smarest.Service.IService;
using Smarest.ViewModel;
using System.Threading.Tasks;

namespace Smarest.Service
{
    public class AddUserToRoleService : IAddUserToRoleService
    {
        private UserManager<IdentityUser> _userManger;
        private RoleManager<IdentityRole> _roleManger;
        

        public AddUserToRoleService(
            UserManager<IdentityUser> userManger, 
            RoleManager<IdentityRole> roleManger)
        {
            _userManger = userManger;
            _roleManger = roleManger;
        }

        public async Task<UserManagerResponse> AddUserToRoleAdmin(User user)
        {
            var adminRole = await _roleManger.FindByNameAsync("Admin");
            var result = await _userManger.AddToRoleAsync(user, adminRole.Name.ToString());
            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Authorized user to admin",
                    IsSuccess = true,
                };
            }
            else
            {
                return new UserManagerResponse
                {
                    Message = "Authorized fail",
                    IsSuccess = false,
                };
            }
        }



        public Task<UserManagerResponse> AddUserToRoleGuest(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> AddUserToRoleManager(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
