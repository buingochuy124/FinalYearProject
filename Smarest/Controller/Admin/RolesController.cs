using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Smarest.Model;
using Smarest.Repository.IRepository;
using Smarest.ViewModel;
using System.Threading.Tasks;

namespace Smarest.Controller.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRoleRepository _roleRepository;
        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("roles")]
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
        [HttpGet("roles")]
        public async Task<IActionResult> GetUserRoles(IdentityUser user)
        {
            var roles = await _roleRepository.GetUserRoles(user);
            if (roles == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return Ok(roles);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRoleManager(IdentityUser user)
        {
            UserManagerResponse result = await _roleRepository.AddUserToRoleManager(user);
            return result.IsSuccess ? Ok() : StatusCode(StatusCodes.Status400BadRequest);
        }




    }
}
