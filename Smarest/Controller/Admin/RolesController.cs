using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarest.Controller.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Utils.Role.Admin)]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleRepository.GetRoles();
            if (roles == null) {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return Ok(roles);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRoles(string id)
        {

            var roles = await _roleRepository.GetUserRoles(id);
            if (roles == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return Ok(roles);
            }
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddUserToRole([FromBody] UserRolesViewModel userRoleViewModel)
        {
            UserManagerResponse result = await _roleRepository.AddUserToRole(userRoleViewModel);
            return result.IsSuccess ? Ok() : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPost("RemoveRole")]
        public async Task<IActionResult> RemoveUserToRole([FromBody] UserRolesViewModel userRoleViewModel)
        {
            UserManagerResponse result = await _roleRepository.RemoveUserFromRole(userRoleViewModel);
            return result.IsSuccess ? Ok() : StatusCode(StatusCodes.Status400BadRequest);
        }



    }
}
