using Smarest.Model;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository.IRepository
{
    public interface ICartRepository
    {
        Task<List<CartViewModel>> GetCartsOfUser(string userId);
        Task<UserManagerResponse> AddItemToUserCart(string itemId,string tableId, string userId);
        Task<UserManagerResponse> DeleteItemFromUserCart(string itemId, string userId);
        Task<UserManagerResponse> ClearCartOfUser(string userId);
    }
}
