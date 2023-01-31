using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
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

        public async Task<UserManagerResponse> Create(Category category)
        {
            try
            {
                var newCategory = new Category
                {
                    Name = category.Name,
                };
                var createCategory = await _context.Categories.AddAsync(newCategory);
                _context.SaveChanges();
                return new UserManagerResponse
                {
                    Message = "Category Created",
                    IsSuccess = true,
                };
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {

                };
            }
        }


        public async Task<List<Category>> GetCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(string Id)
        {
            var category =  await _context.Categories.SingleOrDefaultAsync(c => c.Id == Id);
            return category;
        }

        public async Task<UserManagerResponse> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserManagerResponse> Edit(string id, Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
