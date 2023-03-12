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
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingModel>> GetBookingModel(string id)
        {
            var bookingModel = await _context.Bookings.FindAsync(id);

            if (bookingModel == null)
            {
                return NotFound();
            }

            return bookingModel;
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingModel(string id, BookingModel bookingModel)
        {
            if (id != bookingModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingModel>> PostBookingModel(BookingModel bookingModel)
        {
            _context.Bookings.Add(bookingModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingModelExists(bookingModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingModel", new { id = bookingModel.Id }, bookingModel);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingModel>> DeleteBookingModel(string id)
        {
            var bookingModel = await _context.Bookings.FindAsync(id);
            if (bookingModel == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(bookingModel);
            await _context.SaveChangesAsync();

            return bookingModel;
        }

        private bool BookingModelExists(string id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
