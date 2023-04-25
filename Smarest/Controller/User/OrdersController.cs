using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;

namespace Smarest.Controller.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Guest)]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Orders()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
            result.ForEach(r => r.Date.ToString("MM/dd/yyyy"));
            return result ;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]

        public async Task<ActionResult<List<OrderDetail>>> OrderDetails(string id)
        {
            var orderDetail = await _context.OrderDetails.Where(o => o.OrderId == id).Include(o => o.Item).ToListAsync();

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

     
    }
}
