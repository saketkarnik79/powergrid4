using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_DemoWebAPIBasics.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_DemoWebAPIBasics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CalcApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string?> GetData()
        {
            // This is a simple API that returns a string.
            // It can be used to test the API functionality.
            return Ok("Hello from CalcApiController!");
        }

        [HttpPost("PostAdd")]
        public ActionResult<int> PostAdd([FromBody] Numbers numbers)
        {
            int sum = numbers.N1 + numbers.N2;
            return Ok(sum);
        }
    }
}
