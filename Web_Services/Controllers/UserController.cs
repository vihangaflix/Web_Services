using Microsoft.AspNetCore.Mvc;
using Web_Services.Models;
using Web_Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        // GET: api/<TicketController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userService.GetUsers();
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = userService.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            return user;
        }

        // POST api/<TicketController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userService.CreateUser(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            var existingUser = userService.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound($"User with id = {id} not found");
            }

            userService.UpdateUser(id, user);

            return NoContent();
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user = userService.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User with id = {id} not found");
            }

            userService.DeleteUser(user.Id);

            return Ok($"User with Id = {id} deleted");
        }
    }
}
