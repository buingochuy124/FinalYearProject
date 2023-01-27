using Smarest.Model;
using Smarest.ViewModel;
using System.Threading.Tasks;

namespace Smarest.Service.IService
{
    public interface IAddUserToRoleService
    {
        Task<UserManagerResponse> AddUserToRoleGuest(User user);
        Task<UserManagerResponse> AddUserToRoleManager(User user);
        Task<UserManagerResponse> AddUserToRoleAdmin(User user);


    }
}
