using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;
using Smarest.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smarest.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Category category)
        {
            try
            {
                var newCategory = new Category
                {
                    Name = category.Name,
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(int id, Category category)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetCategory()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public Category GetCategory(int Id)
        {
            var category =  _context.Categories.SingleOrDefault(c => c.Id == Id);
            return category;
        }
    }
}
