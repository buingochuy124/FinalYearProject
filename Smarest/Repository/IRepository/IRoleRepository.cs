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
        Task<List<Role>> GetUserRoles(string id);
        Task<UserManagerResponse> AddUserToRole(UserRolesViewModel userRolesViewModel);
        Task<UserManagerResponse> RemoveUserFromRole(UserRolesViewModel userRolesViewModel);
    }
}
