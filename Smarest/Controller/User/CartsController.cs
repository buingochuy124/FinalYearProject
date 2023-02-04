using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;

namespace Smarest.Controller.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Guest)]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // GET: api/Carts
        [HttpGet("UserCart")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCartsOfUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<Cart> cartOfUser = await _cartRepository.GetCartsOfUser(userId);

            return cartOfUser;
        }      

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddToCart")]
        public async Task<ActionResult<Cart>> AddToUserCart([FromBody]ItemViewModel item)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _cartRepository.AddItemToUserCart(item.Id, userId);
            if(result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE: api/Carts/5
        [HttpDelete("RemoveUserCart")]
        public async Task<ActionResult<Cart>> DeleteFromUserCart([FromBody] ItemViewModel item)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _cartRepository.DeleteItemFromUserCart(item.Id, userId);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("RemoveUserCarts")]
        public async Task<ActionResult<Cart>> ClearFromUserCart()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _cartRepository.ClearCartOfUser(userId);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
