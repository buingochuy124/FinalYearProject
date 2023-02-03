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
                _context.Categories.Add(newCategory);
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
                    Message = "Category create fail...",
                    IsSuccess = false,
                };
            }
        }


        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(string id)
        {
            var category =  await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<UserManagerResponse> Delete(string id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Category Deleted"
            };
        }

        public async Task<UserManagerResponse> Edit(string id, Category category)
        {
          
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetCategory(id) == null)
                {
                    return new UserManagerResponse
                    {
                        IsSuccess = false,
                        Message = "Category not found"

                    };
                }
                else
                {
                    throw;
                }
            }

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Category edited"

            };
        }
    }
}
