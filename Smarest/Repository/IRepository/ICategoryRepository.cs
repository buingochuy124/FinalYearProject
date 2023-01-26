using Smarest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategory();
        Category GetCategory(int Id);
        bool Create(Category category);
        bool Delete(int id);
        bool Edit(int id, Category category);
    }
}
