using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Web_Services.Models;
using Web_Services.Services;

namespace Web_Services.Controllers
{
    [ApiController]
    [Route("api/train")]
    public class TrainController : Controller
    {
        private readonly MongoDBService _mongoDBService;
        private readonly ILogger<TrainController> _logger;
        public TrainController(MongoDBService mongoDBService,
       ILogger<TrainController> logger)
        {
            _mongoDBService = mongoDBService;
            _logger = logger;
        }
        //Create train with schedules
        [HttpPost("create")]
        public async Task<dynamic> CreateTrain([FromBody] Train train)
        {
            var request = Request;
            if (await EventMiddleware.Authorizer(request.Headers["x-api-key"].IsNullOrEmpty() ? null : request.Headers["x-api-key"][0], _mongoDBService))
            {
                return Unauthorized("Unauthorized");
            }
            //prevent traveller to access this resource
            else if (JWTDecoder.DecodeJwtToken(request.Headers["x-api-key"][0]).Payload.ToList()[3].Value.ToString() == "travel-agent")
            {
                return Unauthorized("Unauthorized");
            }
            await _mongoDBService.CreateTrain(train);
            return Ok("Train Schedule Created Successfully");
        }
        //get all train with schedules
        [HttpGet("schedules")]
        public async Task<dynamic> GetSchedules()
        {
            var request = Request;
            if (await EventMiddleware.Authorizer(request.Headers["x-api-key"].IsNullOrEmpty() ? null : request.Headers["x-api-key"][0], _mongoDBService))
            {
                return Unauthorized("Unauthorized");
            }
            return await
           _mongoDBService.GetSchedules(JWTDecoder.DecodeJwtToken(request.Headers["x-api-key"][0]).Payload.ToList()[3].Value.ToString());
        }
        //update schedule
        [HttpPut("schedule/update/{id}")]
        public async Task<dynamic> UpdateSchedule(string id, [FromBody] Train
train)
        {
            var request = Request;
            if (await EventMiddleware.Authorizer(request.Headers["x-api-key"].IsNullOrEmpty() ? null : request.Headers["x-api-key"][0], _mongoDBService))
            {
                return Unauthorized("Unauthorized");
            }
            else if (JWTDecoder.DecodeJwtToken(request.Headers["x-api-key"][0]).Payload.ToList()[3].Value.ToString() == "travel-agent") return Unauthorized("Unauthorized");
            await _mongoDBService.UpdateSchedule(id, train);
            return Ok($"Schedule Updated Successfully");
        }
        //cancel schedule
        [HttpPut("schedule/cancel/{id}")]
        public async Task<dynamic> CancelSchedule(string id, [FromBody] Train
       train)
        {
            var request = Request;
            if (await EventMiddleware.Authorizer(request.Headers["x-api-key"].IsNullOrEmpty() ? null : request.Headers["x-api-key"][0], _mongoDBService))
            {
                return Unauthorized("Unauthorized");
            }
            else if (JWTDecoder.DecodeJwtToken(request.Headers["x-api-key"][0]).Payload.ToList()[3].Value.ToString() == "travel-agent") return Unauthorized("Unauthorized");
            else if (!train.reservations.IsNullOrEmpty())
            {
                return BadRequest("Cannot Cancelled. Already Have Reservations");
            }
            await _mongoDBService.CancelSchedule(id, train);
            return Ok($"Schedule Cancelled Successfully");
        }
    }
}