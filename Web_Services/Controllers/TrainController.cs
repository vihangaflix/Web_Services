using Microsoft.AspNetCore.Mvc;
using Web_Services.Models;
using Web_Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService trainService;

        public TrainController(ITrainService trainService)
        {
            this.trainService = trainService;
        }


        // GET: api/<TicketController>
        [HttpGet]
        public ActionResult<List<Train>> Get()
        {
            return trainService.GetTrains();
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public ActionResult<Train> Get(string id)
        {
            var train = trainService.GetTrainById(id);

            if (train == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            return train;
        }

        // POST api/<TicketController>
        [HttpPost]
        public ActionResult<Train> Post([FromBody] Train train)
        {
            trainService.CreateTrain(train);

            return CreatedAtAction(nameof(Get), new { id = train.Id }, train);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Train train)
        {
            var existingTrain = trainService.GetTrainById(id);

            if (existingTrain == null)
            {
                return NotFound($"Train with id = {id} not found");
            }

            trainService.UpdateTrain(id, train);

            return NoContent();
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var train = trainService.GetTrainById(id);

            if (train == null)
            {
                return NotFound($"Train with id = {id} not found");
            }

            trainService.DeleteTrain(train.Id);

            return Ok($"Train with Id = {id} deleted");
        }
    }
}