using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using API_DemoWebAPIBasics.Models.Auth;
using API_DemoWebAPIBasics.Services;

namespace API_DemoWebAPIBasics.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtTokenIssuanceService _jwtTokenIssuanceService;

        public LoginApiController(SignInManager<IdentityUser> signInManager, JwtTokenIssuanceService jwtTokenIssuanceService)
        {
            _signInManager = signInManager;
            _jwtTokenIssuanceService = jwtTokenIssuanceService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Invalid login request.");
            }
            var result=await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
            if (result.Succeeded)
            {
                var roles = new List<string>() { "PowerUsers" };

                var token = _jwtTokenIssuanceService.GenerateToken(model.Email,roles);
                return Ok(new
                {
                    Message="Login Successful.",
                    token = token
                });
            }
            else
            {
                return Unauthorized("Invalid login attempt.");
            }
        }
    }
}
