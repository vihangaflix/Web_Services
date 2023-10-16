using Microsoft.AspNetCore.Mvc;
using Web_Services.Models;
using Web_Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReservationController : ControllerBase
    {
        private readonly IUserReservationService userReservationService;

        public UserReservationController(IUserReservationService userReservationService)
        {
            this.userReservationService = userReservationService;
        }


        // GET: api/<TicketController>
        [HttpGet("page/{page}")]
        public ActionResult<List<UserReservation>> Get(int page)
        {
            return userReservationService.GetUserReservations(page);
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public ActionResult<UserReservation> Get(string id)
        {
            var userReservation = userReservationService.GetUserReservationById(id);

            if (userReservation == null)
            {
                return NotFound($"User Reservation with Id = {id} not found");
            }

            return userReservation;
        }

        // POST api/<TicketController>
        [HttpPost]
        public ActionResult<UserReservation> Post([FromBody] UserReservation userReservation)
        {
            userReservationService.CreateUserReservation(userReservation);

            return CreatedAtAction(nameof(Get), new { id = userReservation.Id }, userReservation);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] UserReservation userReservation)
        {
            var existingUserReservation = userReservationService.GetUserReservationById(id);

            if (existingUserReservation == null)
            {
                return NotFound($"User Reservation with id = {id} not found");
            }

            userReservationService.UpdateUserReservation(id, userReservation);

            return NoContent();
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUserReservation = userReservationService.GetUserReservationById(id);

            if (existingUserReservation == null)
            {
                return NotFound($"User Reservation with id = {id} not found");
            }

            userReservationService.DeleteUserReservation(existingUserReservation.Id);

            return Ok($"Train with Id = {id} deleted");
        }
    }
}
