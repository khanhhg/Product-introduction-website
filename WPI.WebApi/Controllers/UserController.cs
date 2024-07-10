using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WPI.WebApi.Data.Models;
using WPI.WebApi.Data.Models.UserModel;

namespace WPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sign;
        private readonly IConfiguration _configuration;
        public UserController(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,         
            SignInManager<IdentityUser> sign)
        {
            _userManager = userManager;           
            _configuration = configuration;          
            _sign = sign;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _sign.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded && !result.IsLockedOut)
                {

                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                          new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GetToken(authClaims);
                   
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        userID = user.Id,
                        UserName = user.UserName
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Username is exits" });
            }
            else
            {
                IdentityUser user = new()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    LockoutEnabled = false
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Registration failed please check again" });
                }
                else
                {                  
                    return Ok(new ResponseModel { Status = "Success", Message = "Register user success!" });
                }
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userID);
            if (user == null)
            {
                return Ok("User does not exist");
            }
            else
            {
                IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
                }
                else
                {
                    return Ok("Change password success");
                }
            }
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ChangePasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userID);
            if (user == null)
            {
                return Ok("User does not exist");
            }
            else
            {
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                IdentityResult result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
                }
                else
                {
                    return Ok("Reset password success");
                }
            }
        }

        
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteNguoiDung(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Ok("User does not exist");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
                }
                else
                {
                    return Ok("Delete user success");
                }
            }
        }

        [HttpPost]
        [Route("LockUser")]
        public async Task<ActionResult> LockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Ok("User does not exist");
            }
            else
            {

                var result = await _userManager.SetLockoutEnabledAsync(user, true);
                var ThoiGianKhoa = await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(100));
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
                }
                else
                {
                    return Ok("Lock user success");

                }
            }
        }

        [HttpPost]
        [Route("UnLockUser")]
        public async Task<ActionResult> UnLockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Ok("User does not exist");
            }
            else
            {
                var result = await _userManager.SetLockoutEnabledAsync(user, false);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
                }
                else
                {
                    return Ok("UnLock user success");
                }
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
