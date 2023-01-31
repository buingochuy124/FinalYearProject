using Smarest.Model;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategory();
        Task<Category> GetCategory(string Id);
        Task<UserManagerResponse> Create(Category category);
        Task<UserManagerResponse> Delete(string id);
        Task<UserManagerResponse> Edit(string id, Category category);
    }
}
