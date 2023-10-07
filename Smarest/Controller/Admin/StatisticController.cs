using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Smarest.Controller.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Admin)]
    public class StatisticController : ControllerBase
    {
        private ApplicationDbContext _context { get; set; }

        public StatisticController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("DashboardStats")]
        public async Task<ActionResult> DashboardStats(DashboardViewModel dashboardViewModel)
        {
            DashboardResponseViewModel result = new DashboardResponseViewModel();
            List<Order> ordersInDateRange = await _context.Orders
                .Where(order => order.Date >= dashboardViewModel.StartDate && order.Date <= dashboardViewModel.EndDate)
                .Include(order => order.User)
                .ToListAsync();


            result.UserCount =  await _context.Users.CountAsync();


            ordersInDateRange.ForEach(order => result.TotalSales += order.Total);
            ordersInDateRange.ForEach(order => result.OrdersCount+=1);

            return Ok(result);
                    
        }
        [HttpGet("DashBoardLineData")]
        public async Task<ActionResult> DashBoardLineData()
        {
            DateTime fromDate = DateTime.Now.AddMonths(-3);
            var orders = await _context.Orders
                .Where(order => order.Date >= fromDate && order.Date <= DateTime.Now)
                .ToListAsync();

            List<double> result = new List<double>();
            result.Add(0.0);
            result.Add(0.0);
            result.Add(0.0);
            foreach (var order in orders)
            {
                if(order.Date.Month == DateTime.Now.AddMonths(-3).Month)
                {
                    result[0] += order.Total;
                }
                else if (order.Date.Month == DateTime.Now.AddMonths(-2).Month)
                {
                    result[1] += order.Total;
                }
                else
                {
                    result[2] += order.Total;
                }
            }

           
            return Ok(result);

        }

        
    }
}
