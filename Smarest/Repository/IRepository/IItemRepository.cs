using Smarest.Model;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository.IRepository
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItems();
        Task<Item> GetItem(string Id);
        Task<List<Item>> GetFoods();
        Task<UserManagerResponse> Create(Item item);
        Task<UserManagerResponse> Delete(string id);
        Task<UserManagerResponse> Edit(string id, Item item);

    }
}
