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
using Smarest.ViewModel;

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
            var result = await _context.Orders.Where(o => o.UserId == userId).OrderByDescending(o => o.Date).ToListAsync();
            result.ForEach(r => r.Date.ToString("MM/dd/yyyy"));
            return result ;
        }

        [HttpGet("AdminGetOrders")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Admin)]
        public async Task<ActionResult<List<Order>>> AdminGetOrders()
        {
            var result = await _context.Orders.Include(r => r.User).OrderByDescending(o => o.Date).ToListAsync();
            result.ForEach(r => r.UserName = r.User.UserName);
            return result ;
        }
        [HttpGet("ManagerGetOrders")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Manager)]
        public async Task<ActionResult<List<Order>>> ManagerGetOrders()
        {
            DateTime currentDate = DateTime.Today;

            var result = await _context.Orders.Include(r => r.User)
                .Where(o => o.Date.Date == currentDate)
                .OrderByDescending(o => o.Date).ToListAsync();
            
            result.ForEach(r => r.UserName = r.User.UserName);
            return result;
        }

        [HttpGet("TodayStatistic")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Admin)]
        public async Task<ActionResult<List<TodayStatistics>>> OrderTodayStatistics()
        {

            var orders = await _context.Orders.Where(o => o.Date == DateTime.Today).Include(r => r.User).ToListAsync();
            orders.ForEach(r => r.UserName = r.User.UserName);

            return orders
               .GroupBy(order => order.Date.Hour)
               .Select(group => new TodayStatistics
               {
                   Time = group.Key,
                   TotalOrders = group.Count(),
                   TotalSales = group.Sum(order => order.Total),
                   AverageOrderValue = group.Average(order => order.Total)
               })
               .ToList();
         
        }
        [HttpGet("YearlyStatistics")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Admin)]
        public async Task<ActionResult<List<YearlyStatistics>>> OrderYearlyStatistics()
        {
            var orders = await _context.Orders.Include(r => r.User).ToListAsync();
            orders.ForEach(r => r.UserName = r.User.UserName);

            return orders
               .GroupBy(order => order.Date.Year)
               .Select(group => new YearlyStatistics
               {
                   Year = group.Key,
                   TotalOrders = group.Count(),
                   TotalSales = group.Sum(order => order.Total),
                   AverageOrderValue = group.Average(order => order.Total)
               })
               .ToList();
        }

        [HttpGet("DailyStatistics")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Admin)]
        public async Task<ActionResult<List<DailyStatistics>>> OrderDailyStatistics()
        {
            var orders = await _context.Orders.Include(r => r.User).ToListAsync();
            orders.ForEach(r => r.UserName = r.User.UserName);

            return orders
               .GroupBy(order => new { Date = order.Date.Date })
               .Select(group => new DailyStatistics
               {
                   Date = group.Key.Date,
                   TotalOrders = group.Count(),
                   TotalSales = group.Sum(order => order.Total),
                   AverageOrderValue = group.Average(order => order.Total)
               })
               .ToList();
        }

        [HttpGet("MonthlyStatistics")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Admin)]
        public async Task<ActionResult<List<MonthlyStatistics>>> OrderMonthlyStatistics()
        {
            var orders = await _context.Orders.Include(r => r.User).ToListAsync();
            orders.ForEach(r => r.UserName = r.User.UserName);

            return orders
                 .GroupBy(order => new { Year = order.Date.Year, Month = order.Date.Month })
                 .Select(group => new MonthlyStatistics
                 {
                     Year = group.Key.Year,
                     Month = group.Key.Month,
                     TotalOrders = group.Count(),
                     TotalSales = group.Sum(order => order.Total),
                     AverageOrderValue = group.Average(order => order.Total)
                 })
                 .ToList();
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
