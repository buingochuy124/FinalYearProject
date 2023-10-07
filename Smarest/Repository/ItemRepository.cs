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
    public class ItemRepository : IItemRepository
    {
        private ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserManagerResponse> Create(Item item)
        {
            _context.Items.Add(item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                if(GetItem(item.Id) != null)
                {
                    return new UserManagerResponse
                    {
                        IsSuccess = false,
                        Message = "Item Already Exist ..."
                    };
                }
                throw;
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Item Created ..."
            };
        }

        public async Task<UserManagerResponse> Delete(string id)
        {
            var item = await GetItem(id);
            if (item == null)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Item not found ..."
                };
            }
            
            _context.Items.Remove(item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Some thing went wrong ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Item Deleted ..."
            };
        }

        public async Task<UserManagerResponse> Edit(string id, Item item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                if(GetItem(id) == null)
                {
                    return new UserManagerResponse
                    {
                        IsSuccess = false,
                        Message = "Item not found ..."
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
                Message = "Item Edited ..."
            };

        }

        public async Task<List<Item>> GetFoods()
        {
            var food =  _context.Categories.SingleOrDefault(c => c.Name == "Main Dishes");
            var foods =  await _context.Items.Where(f => f.CategoryId == food.Id).ToListAsync();
            return foods;
        }

        public async Task<List<Item>> GetDrinks()
        {
            var food = _context.Categories.SingleOrDefault(c => c.Name == "Drink");
            var foods = await _context.Items.Where(f => f.CategoryId == food.Id).ToListAsync();
            return foods;
        }

        public async Task<List<Item>> GetOther()
        {
            var food = _context.Categories.SingleOrDefault(c => c.Name == "Other");
            var foods = await _context.Items.Where(f => f.CategoryId == food.Id).ToListAsync();
            return foods;
        }

        public async Task<Item> GetItem(string id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public async Task<List<Item>> GetItems()
        {
            var items = new List<Item>();
            try
            {
                items = await _context.Items.ToListAsync();
            }
            catch (System.Exception)
            {
                return items;         
            }
            return items;

        }

    }
}
