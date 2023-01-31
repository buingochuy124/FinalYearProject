using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _categoryRepos;

        public CategoriesController(ICategoryRepository categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<Category> categories = await _categoryRepos.GetCategory();
            if (categories == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return Ok(categories);

        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(string id)
        {
            Category category = await _categoryRepos.GetCategory(id);
            if (category == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(category);
        }
        // POST: api/Categories/create

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            UserManagerResponse result = await _categoryRepos.Create(category);
            return result.IsSuccess ? StatusCode(StatusCodes.Status204NoContent) : BadRequest();
           
        }

        // DELETE: api/Categories/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            UserManagerResponse result = await _categoryRepos.Delete(id);
            return result.IsSuccess ? StatusCode(StatusCodes.Status204NoContent) : BadRequest();

        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(string id, Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            UserManagerResponse result = await _categoryRepos.Edit(id, category);
            return result.IsSuccess ? StatusCode(StatusCodes.Status204NoContent) : BadRequest();
        }
    }
}
