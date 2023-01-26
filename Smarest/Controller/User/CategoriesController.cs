using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _categoryRepos;

        public CategoriesController(ICategoryRepository categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepos.GetCategory();
            if (categories == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return Ok(categories);

        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepos.GetCategory(id);
            if (category == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(category);
        }
        // POST: api/Categories/create

        [HttpPost("create")]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = _categoryRepos.Create(category);
            return result ? StatusCode(StatusCodes.Status204NoContent) : BadRequest();
        }

        // DELETE: api/Categories/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryRepos.Delete(id);
            return result ? StatusCode(StatusCodes.Status204NoContent) : BadRequest();

        }
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = _categoryRepos.Edit(id, category);
            return result ? StatusCode(StatusCodes.Status204NoContent) : BadRequest();
        }
    }
}
