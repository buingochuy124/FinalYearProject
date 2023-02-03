using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smarest.Data;
using Smarest.Model;
using Smarest.Repository.IRepository;

namespace Smarest.Controller.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepos;
        public ItemsController(IItemRepository itemRepos)
        {
            _itemRepos = itemRepos;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = await _itemRepos.GetItems();
            if (items == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return Ok(items);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(string id)
        {
            var item = await _itemRepos.GetItem(id);

            if (item == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return Ok(item);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, Item item)
        {
            var result = await _itemRepos.Edit(id, item);


            return NoContent();
        }

        //// POST: api/Items
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Item>> PostItem(Item item)
        //{
        //    _context.Items.Add(item);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ItemExists(item.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetItem", new { id = item.Id }, item);
        //}

        //// DELETE: api/Items/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Item>> DeleteItem(string id)
        //{
        //    var item = await _context.Items.FindAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Items.Remove(item);
        //    await _context.SaveChangesAsync();

        //    return item;
        //}

        //private bool ItemExists(string id)
        //{
        //    return _context.Items.Any(e => e.Id == id);
        //}
    }
}
