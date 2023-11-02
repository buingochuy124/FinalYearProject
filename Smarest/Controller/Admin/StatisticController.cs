using EllipticCurve.Utils;
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

        [HttpPost("DashBoardBarData")]
        public async Task<ActionResult> DashBoardBarData(DashboardViewModel dashboardViewModel)
        {
            DateTime fromDate = dashboardViewModel.EndDate.AddMonths(-3);

            var orderDetails = await _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Item)
                .Where(od => od.Order.Date >= fromDate && od.Order.Date <= dashboardViewModel.EndDate)
                .OrderByDescending(od => od.Quantity).ToListAsync();


            List<SalesReport> salesReports = new List<SalesReport>();
                
            List<string> itemIds = orderDetails.Select(od => od.Item.Id).Distinct().ToList();

            foreach (var itemId in itemIds)
            {
                salesReports.Add(new SalesReport
                {
                    TotalQuantitySold = orderDetails.Where(orderDetail => orderDetail.Item.Id == itemId)
                    .Sum(od => od.Quantity),

                    ItemName = _context.Items.SingleOrDefault(i => i.Id==itemId).Name
                }) ;
            }
            var  result = salesReports.OrderByDescending(salesReport =>salesReport.TotalQuantitySold);
            return Ok(result.Take(3));
        }
        [HttpPost("DashBoardLineData")]
        public async Task<ActionResult> DashBoardLineData(DashboardViewModel dashboardViewModel)
        {
            DateTime fromDate = dashboardViewModel.EndDate.AddMonths(-3);

            var orders = await _context.Orders
                .Where(order => order.Date >= fromDate && order.Date <= dashboardViewModel.EndDate)
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

        [HttpPost("DashBoardUserData")]
        public async Task<ActionResult> DashBoardUserData(DashboardViewModel dashboardViewModel)
        {
            DateTime fromDate = dashboardViewModel.EndDate.AddMonths(-3);   

            var orders = await _context.Orders
                .Include(or => or.User)
                .OrderByDescending(o => o.Total).ToListAsync();
            var dashBoardUserDataResponse = new List<DashBoardUserDataResponse>();
            orders.ForEach(o => o.OrderDetails = _context.OrderDetails.Where(orderDetails => orderDetails.OrderId == o.Id).ToList());
            List<string> userEmails = orders.Select(od => od.User.Email).Distinct().ToList();
            foreach (var order in orders)
            {
                int quantity = 0;
                order.OrderDetails.ForEach(or => quantity += or.Quantity);
                dashBoardUserDataResponse.Add(new DashBoardUserDataResponse
                {
                    Email = order.User.Email,
                    TotalAmount = order.Total,
                    OrderedQuantity = quantity
                }); 
            }
            var result = new List<DashBoardUserDataResponse>();
            foreach (var userEmail in userEmails)
            {
                var group = dashBoardUserDataResponse.Where(d => d.Email ==  userEmail).ToList();

                var sum = group.Sum(u => u.TotalAmount);
                var quantity = group.Sum(u => u.OrderedQuantity);
                result.Add(new DashBoardUserDataResponse
                {
                    Email = userEmail,
                    TotalAmount = sum,
                    OrderedQuantity = quantity
                });
            }
           
            return Ok(result.Take(5));

        }
        [HttpPost("DashBoardDoughnutData")]
        public async Task<ActionResult> DashBoardDoughnutData(DashboardViewModel dashboardViewModel)
        {
            DateTime fromDate = dashboardViewModel.EndDate.AddMonths(-3);

            return Ok();

        }

    }
}
