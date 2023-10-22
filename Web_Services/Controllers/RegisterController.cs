using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using Web_Services.Models;
using Web_Services.Services;
/* Controller for Register
* All the Register Related enpoints goes here
*/
namespace Web_Services.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [ApiController]
    [Route("api/auth")]
    public class RegisterController : Controller
    {
        private readonly MongoDBService _mongoDBService;
        private readonly ILogger<RegisterController> _logger;
        public RegisterController(MongoDBService mongoDBService,
        ILogger<RegisterController> logger)
        {
            _mongoDBService = mongoDBService;
            _logger = logger;
        }
        //Get User endpoint
        [HttpGet("user")]
        public async Task<List<Auth>> Get()
        {
            return await _mongoDBService.GetUserAsync();
        }
        //Register API endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Auth user)
        {
            //Check for the user already existence
            foreach (var i in await _mongoDBService.GetUserAsync())
            {
                if (i.email?.ToLower() == user.email?.ToLower() ||
               i.nic?.ToLower() == user.nic?.ToLower())
                {
                    return BadRequest("Invalid User");
                }
            }
            await _mongoDBService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.email }, user);
        }

    }
}