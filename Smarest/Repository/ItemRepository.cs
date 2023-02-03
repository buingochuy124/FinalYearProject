using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository
{
    public class ItemRepository : IItemRepository
    {
        public Task<UserManagerResponse> Create(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserManagerResponse> Edit(string id, Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItem(string Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Item>> GetItems()
        {
            throw new System.NotImplementedException();
        }
    }
}
