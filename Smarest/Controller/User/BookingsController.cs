using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.Where(b => b.BookingDate > DateTime.Now).ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingModel(string id)
        {
            var bookingModel = await _context.Bookings.FindAsync(id);

            if (bookingModel == null)
            {
                return NotFound();
            }

            return bookingModel;
        }
        [HttpPost("createBooking")]
        public async Task<ActionResult<UserManagerResponse>> CreateNewBooking(BookingViewModel bookingViewModel)
        {
            var booking = new Booking
            {
                UserId = bookingViewModel.UserId,
                BookingDate = bookingViewModel.BookingDate,
                TableName = bookingViewModel.TableName,
            };
            var result = _context.Bookings.Add(booking);
            return Ok(result);
        }
    }
}
