using Microsoft.AspNetCore.Mvc;
using Web_Services.Models;
using Web_Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }


        [HttpGet("page/{page}")]
        public ActionResult<List<Ticket>> Get(int page)
        {
            return ticketService.GetTickets(page);
        }

        [HttpGet("status")]
        public ActionResult<List<Ticket>> GetByStatus(int status)
        {
            return ticketService.GetTicketsByStatus(status);
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public ActionResult<Ticket> Get(string id)
        {
            var ticket = ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound($"Ticket with Id = {id} not found");
            }

            return ticket;
        }

        // POST api/<TicketController>
        [HttpPost]
        public ActionResult<Ticket> Post([FromBody] Ticket ticket)
        {
            ticketService.CreateTicket(ticket);

            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Ticket ticket)
        {
            var existingTicket = ticketService.GetTicketById(id);

            if (existingTicket == null)
            {
                return NotFound($"Ticket with id = {id} not found");
            }

            ticketService.UpdateTicket(id, ticket);

            return NoContent();
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var ticket = ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound($"Ticket with id = {id} not found");
            }

            ticketService.DeleteTicket(ticket.Id);

            return Ok($"Ticket with Id = {id} deleted");
        }
    }
}
