using Microsoft.AspNetCore.Identity;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System.Collections.Generic;
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

        public Task<UserManagerResponse> AddUserToGuest(IdentityUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> AddUserToRoleAdmin(IdentityUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> AddUserToRoleManager(IdentityUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Role>> GetRoles()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Role>> GetUserRoles(IdentityUser user)
        {
            var roles = await _userManger.GetRolesAsync(user);
            var result = new List<Role>();
            foreach (var role in roles)
            {
                result.ForEach(r => r.Name = role);
            }
            return result;
        }

        public Task<UserManagerResponse> RemoveUserFromAdminRole(IdentityUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> RemoveUserFromManagerRole(IdentityUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
