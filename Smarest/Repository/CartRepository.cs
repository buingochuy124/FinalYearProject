using Microsoft.AspNetCore.Identity;
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
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CartRepository(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<UserManagerResponse> AddItemToUserCart(string itemId, string userId)
        {
            var cartFromUser = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            var item = cartFromUser.SingleOrDefault(c => c.ItemId == itemId);
            if(item != null)
            {
                item.ItemQuantity += 1;
                _context.Carts.Update(item);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    IsSuccess = true,
                    Message = "Quantity Updated ..."
                };
            }
            var newItem = new Cart
            {
                ItemId = itemId,
                UserId = userId
            };
            _context.Carts.Add(newItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Some Thing Wrong ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Added To Cart..."
            };

        }

        public async Task<UserManagerResponse> ClearCartOfUser(string userId)
        {
            var cartFromUser = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            _context.Carts.RemoveRange(cartFromUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Clear Cart Fail, Please try again ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Cleared Cart ..."
            };
        }

        public async Task<UserManagerResponse> DeleteItemFromUserCart(string itemId, string userId)
        {
            var cartFromUser = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            var item = cartFromUser.SingleOrDefault(c => c.ItemId == itemId);
            if (item == null)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Item Not Found ..."
                };
            }

            _context.Carts.Remove(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Some Thing Wrong ..."
                };
            }
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Removed From Cart..."
            };
        }

        public async Task<List<Cart>> GetCartsOfUser(string userId)
        {
            var carts = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            return carts;
        }
    }
}
