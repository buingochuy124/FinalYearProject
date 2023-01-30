using Smarest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategory();
        Category GetCategory(string Id);
        bool Create(Category category);
        bool Delete(string id);
        bool Edit(string id, Category category);
    }
}
