using MediatR;
using MeetUp.Application.DomainHandlers.Events.Commands.JoinToEventCommands;
using MeetUp.Application.DomainHandlers.Events.Queries.GetAttendedEventsByUserIdQuery;
using MeetUp.Application.DomainHandlers.Events.Queries.GetEventAttendess;
using MeetUp.Persistence.UtilitiesConcrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeetUp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendedEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendedEventController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost("attend/{id}")]
        public async Task<ActionResult<Result>> JoinToEvent([FromRoute] int id)
        {
            await _mediator.Send(new JoinToEventCommandRequest()
            {
                EventId = id,
                ApplicationUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)

            });
            return Ok();
        }

        [HttpGet("event-attendees/{id}")]
        public async Task<ActionResult<Result>> GetEventAttendees([FromRoute] int id)
        {
            var items = await _mediator.Send(new GetEventAttendeesQueryRequest()
            {
                EventId = id
            });
            return Result.Ok(items, "getting event attendes has been completed with success");
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpGet("user-attended")]
        public async Task<ActionResult<Result>> GetUserAttendedEventsAsync()
        {
            var items = await _mediator.Send(new GetAttendedEventsByUserIdQueryRequest()
            {
                ApplicationUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)

            });
            return Ok(items);
        }
    }
}
