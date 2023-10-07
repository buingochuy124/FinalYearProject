using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;

namespace Smarest.Controller.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrderDetail>>> GetOrderDetail(string id)
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
