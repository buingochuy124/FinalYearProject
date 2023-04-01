using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Smarest.Data;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
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
        public async Task<UserManagerResponse> AddItemToUserCart(string itemId, string tableId, string userId)
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
                ItemQuantity = 1,
                UserId = userId
            };
            newItem.TableId = tableId;
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

        public async Task<List<CartViewModel>> GetCartsOfUser(string userId)
        {
            var carts = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            var result = new List<CartViewModel>();
            foreach (var item in carts)
            {
                result.Add(new CartViewModel
                {
                    Id = item.Id,
                    ItemId = item.ItemId,
                    UserId = item.UserId,
                    ItemQuantity = item.ItemQuantity,         
                });
            };

            result.ForEach(r => r.ItemName = _context.Items
                .SingleOrDefault(i => i.Id == r.ItemId)
                .Name);
            result.ForEach(r => r.Cost = _context.Items
              .SingleOrDefault(i => i.Id == r.ItemId)
              .Cost);
            result.ForEach(r => r.ItemImageUrl = _context.Items
              .SingleOrDefault(i => i.Id == r.ItemId)
              .ImageUrl);
            result.ForEach(r => r.User = _context.Users
                     .SingleOrDefault(i => i.Id == r.UserId));
            return result;
        }

        public async Task<UserManagerResponse> UserCheckOut(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(accessToken);


            //string userId =  decodedToken.Claims
            //    .FirstOrDefault(c => c.Type == "nameidentifier")?
            //    .Value;
            var userId = decodedToken.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault();

            var cartOfUser = _context.Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.Item)            
                .ToList();

            double cartTotal = 0;
            foreach (var cart in cartOfUser)
            {
                cartTotal += cart.Item.Cost * cart.ItemQuantity;
            }
            var newOrder = new Order
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Total = cartTotal,
                Date = DateTime.Now,
                
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            foreach (var cart1 in cartOfUser)
            {
                _context.OrderDetails.Add(new OrderDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    OrderId = newOrder.Id,
                    ItemId = cart1.ItemId,
                    Quantity = cart1.ItemQuantity,             
                });
            }
            _context.SaveChanges();
            await ClearCartOfUser(userId);

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = userId,
            };
        }
    }
}
