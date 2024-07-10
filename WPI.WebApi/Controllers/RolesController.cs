using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WPI.WebApi.Data.Models.UserModel;
using WPI.WebApi.Services.Generic;

namespace GD_HTQL.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolesController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public IActionResult Post(string RoleName)
        {
            if (!_roleManager.RoleExistsAsync(RoleName).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(RoleName)).GetAwaiter().GetResult();
                return Ok("Create Success");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Roles already exists in the system");
            }
        }

        [HttpPost]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdataRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
                }
                else
                {
                    return Ok("Update Success");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Not found " + roleName + " in the system");
            }
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> Delete(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
                }
                else
                {
                    return Ok("Delete Success");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Not found " + roleName + " in the system");
            }
        }
        [HttpPost]
        [Route("AddRoleClaims/{roleName}")]
        public async Task<IActionResult> AddRoleClaims(string roleName, ClaimModel claimModel)
        {
            var roleResult = await _roleManager.FindByNameAsync(roleName);
            if (roleResult == null)
            {
                roleResult = new IdentityRole(roleName);
                await _roleManager.CreateAsync(roleResult);
            }
            var roleClaimList = (await _roleManager.GetClaimsAsync(roleResult)).Select(p => p.Type);
            if (!roleClaimList.Contains(claimModel.ClaimType))
            {
                var obj = await _roleManager.AddClaimAsync(roleResult, new Claim(claimModel.ClaimType, claimModel.ClaimValue));
            }
            return Ok(roleClaimList);
        }

        [HttpPost]
        [Route("RemoveRoleClaims/{roleName}")]
        public async Task<IActionResult> RemoveRoleClaims(string roleName, ClaimModel claimModel)
        {
            var roleResult = await _roleManager.FindByNameAsync(roleName);
            if (roleResult == null)
            {
                var roleClaimList = (await _roleManager.GetClaimsAsync(roleResult)).Select(p => p.Type);
                if (!roleClaimList.Contains(claimModel.ClaimType))
                {
                    var obj = await _roleManager.RemoveClaimAsync(roleResult, new Claim(claimModel.ClaimType, claimModel.ClaimValue));
                }
                return Ok();
            }
            else
            {
                return Ok("Roles already exists in the system");
            }
        }

        [HttpPost]
        [Route("AddUserClaims/{userName}")]
        public async Task<IActionResult> AddUserClaims(string userName, ClaimModel claimModel)
        {
            var userResult = await _userManager.FindByNameAsync(userName);
            if (userResult != null)
            {
                var userClaimList = (await _userManager.GetClaimsAsync(userResult)).Select(p => p.Type);
                if (!userClaimList.Contains(claimModel.ClaimType))
                {
                    var obj = await _userManager.AddClaimAsync(userResult, new Claim(claimModel.ClaimType, claimModel.ClaimValue));
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("RemoveUserClaims/{userName}")]
        public async Task<IActionResult> RemoveUserClaims(string userName, ClaimModel claimModel)
        {
            var userResult = await _userManager.FindByNameAsync(userName);
            if (userResult != null)
            {
                var userClaimList = (await _userManager.GetClaimsAsync(userResult)).Select(p => p.Type);
                if (!userClaimList.Contains(claimModel.ClaimType))
                {
                    await _userManager.RemoveClaimAsync(userResult, new Claim(claimModel.ClaimType, claimModel.ClaimValue));

                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(int Id, string roleName)
        {
            string _userID = _unitOfWork.UserProfileRepos.GetById(Id).User_Id;
            var userResult = await _userManager.FindByIdAsync(_userID);
            var roleResult = await _roleManager.FindByNameAsync(roleName);

            if (userResult != null)
            {
                if (roleResult != null)
                {
                    if (!await _userManager.IsInRoleAsync(userResult, roleName))
                    {
                        _userManager.AddToRoleAsync(userResult, roleName).GetAwaiter().GetResult();
                        return Ok("Add user to role success");
                    }
                    else
                    {
                        return Ok("The user already belongs to this role");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Role does not exist");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User does not exist");
            }
        }
        [HttpPost]
        [Route("RemoveUserToRole")]
        public async Task<IActionResult> RemoveUserToRole(int Id, string roleName)
        {
            string _userID = _unitOfWork.UserProfileRepos.GetById(Id).User_Id;
            var userResult = await _userManager.FindByIdAsync(_userID);
            var roleResult = await _roleManager.FindByNameAsync(roleName);
            if (userResult != null)
            {
                if (roleResult != null)
                {
                    _userManager.RemoveFromRoleAsync(userResult, roleName).GetAwaiter().GetResult();
                    return Ok("Delete user from role success");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Role does not exist");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User does not exist");
            }
        }
        [HttpGet]
        [Route("GetAllRoleOfUser")]
        public async Task<IActionResult> GetAllRoleOfUser(int Id)
        {
            string _userID = _unitOfWork.UserProfileRepos.GetById(Id).User_Id;
            var userResult = await _userManager.FindByIdAsync(_userID);

            if (userResult != null)
            {
                var rolesList = _userManager.GetRolesAsync(userResult);
                return Ok(rolesList.Result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User does not exist");
            }
        }

        [HttpGet]
        [Route("GetAllUserOfRole")]
        public async Task<IActionResult> GetAllUserOfRole(string roleName)
        {         
            var roleList = await _roleManager.FindByNameAsync(roleName);
            if (roleList != null)
            {
                var obj = await _userManager.GetUsersInRoleAsync(roleName);
                if (obj != null)
                {
                    var objUserID = obj.Select(x => x.Id).ToList();
                    var objUserProfile = _unitOfWork.UserProfileRepos.Find(x => objUserID.Contains(x.User_Id));
                    //var objUserProfileShort = _mapper.Map<List<NhanVienShortView>>(objUserProfile);
                    return Ok(objUserProfile);
                }
                else
                {
                    return Ok("There are no users in this role");
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Role does not exist");
            }
        }
    }
}
