using Microsoft.AspNetCore.Identity;
using Smarest.Model;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository.IRepository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoles();
        Task<List<Role>> GetUserRoles(IdentityUser user);
        Task<UserManagerResponse> AddUserToRoleAdmin(IdentityUser user);
        Task<UserManagerResponse> AddUserToRoleManager(IdentityUser user);
        Task<UserManagerResponse> AddUserToGuest(IdentityUser user);
        Task<UserManagerResponse> RemoveUserFromAdminRole(IdentityUser user);
        Task<UserManagerResponse> RemoveUserFromManagerRole(IdentityUser user);
    }
}
