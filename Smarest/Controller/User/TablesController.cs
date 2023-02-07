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
using Smarest.ViewModel;

namespace Smarest.Controller.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Manager)]
    public class TablesController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;

        public TablesController(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        // GET: api/Tables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            var tables = await _tableRepository.GetTables();
            if(tables == null)
            {
                return BadRequest();
            }
            return Ok(tables);
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(string id)
        {
            var table = await _tableRepository.GetTable(id);
            if (table == null)
            {
                return BadRequest();
            }
            return Ok(table);
        }

        // PUT: api/Tables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(string id ,[FromBody] TableViewModel model )
        {
            var result = await _tableRepository.Edit(id, model);
            if(result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST: api/Tables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(TableViewModel table)
        {
            var result = await _tableRepository.Create(table);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Table>> DeleteTable(string id)
        {
            var result = await _tableRepository.Delete(id);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }    
    }
}
