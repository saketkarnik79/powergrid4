using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_DemoWebAPIBasics.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace API_DemoWebAPIBasics.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationApiController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRegistrationApiController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid user data.");
            }
            var user = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result= await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }
            return BadRequest(result.Errors);
        }
    }
}
