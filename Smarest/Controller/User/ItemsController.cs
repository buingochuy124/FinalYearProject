using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Guest)]

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Manager)]
        public async Task<IActionResult> Edit(string id, Item item)
        {
            var result = await _itemRepos.Edit(id, item);
            if(result.IsSuccess == false)
            {
                return StatusCode(StatusCodes.Status409Conflict,result.Message);
            }
            return Ok(result);
        }

        // POST: api/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            var result = await _itemRepos.Create(item);
            if(result.IsSuccess == false)
            {
                return StatusCode(StatusCodes.Status409Conflict,result);
            }
            return Ok(result);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(string id)
        {
            var result = await _itemRepos.Delete(id);
            if (result.IsSuccess == false)
            {
                return StatusCode(StatusCodes.Status409Conflict, result);
            }
            return Ok(result);
        }

       
    }
}
