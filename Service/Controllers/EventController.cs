/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace EventQuery.Service
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;

    [ApiController]
   
    public class EventController : ControllerBase
    {
        private ILogger<EventController> logger;
        private IEventManager eventManager;
        public EventController(ILogger<EventController> logger, IEventManager eventManager)
        {
            this.logger = logger;
            this.eventManager = eventManager;
        }


        [HttpGet("events/{eventId:guid}")]
        public IActionResult Get(Guid eventId)
        {
            logger.LogInformation("Saving Profile");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return Ok(eventManager.GetEvent(eventId));
        }

        [HttpGet("events/user/{userId:guid}")]       
        public IActionResult GetEventsByUserId(Guid userId)
        {
            logger.LogInformation("Fetching Events for User.");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return Ok(eventManager.GetEventsByUserId(userId));
        }

        [HttpGet("events/running/user/{userId:guid}")]
        public IActionResult GetRunningEventsByUserId(Guid userId)
        {
            logger.LogInformation("Fetching currently runningEvents for User.");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return Ok(eventManager.GetRunningEventsByUserId(userId));
        }
    }
}
