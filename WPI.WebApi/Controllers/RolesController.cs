using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;     
        public RolesController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;         
        }
        [HttpGet]
        [Route("GetRole")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }
        [HttpGet]
        [Route("GetRoleByID")]
        public async Task<IActionResult> GetRoleByID(string ID)
        {
            return Ok(await _roleManager.FindByIdAsync(ID));
        }
        [HttpGet]
        [Route("GetRoleByName")]
        public async Task<IActionResult> GetRoleByName(string RoleName)
        {
            return Ok(await _roleManager.FindByNameAsync(RoleName));
        }
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> Post(IdentityRole objRole)
        {
            var result = await _roleManager.CreateAsync(objRole);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
            else
            {
                return Ok("Create role success");
            }
        }

        [HttpPost]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdataRole(IdentityRole objRole)
        {
            var result = await _roleManager.UpdateAsync(objRole);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
            else
            {
                return Ok("Update role success");
            }

        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> Delete(IdentityRole objRole)
        {
            var result = await _roleManager.DeleteAsync(objRole);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
            else
            {
                return Ok("Delete role success");
            }
        }
        [HttpPost]
        [Route("AddRoleClaims")]
        public async Task<IActionResult> AddRoleClaims(IdentityRole objRole)
        {
            await _roleManager.AddClaimAsync(objRole, new Claim("isAdmin", "True"));
            var result = await _roleManager.UpdateAsync(objRole);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
            else
            {
                return Ok("Add role claims success");
            }

        }
    }
}
