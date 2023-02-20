using System.Security.Claims;
using MediatR;
using MeetUp.Application.DomainHandlers.Comments.Commands.CreateCommentCommand;
using MeetUp.Application.DomainHandlers.Events.Commands.AddEventToFavCommands;
using MeetUp.Application.DomainHandlers.Events.Commands.CreateEventCommands;
using MeetUp.Application.DomainHandlers.Events.Commands.DeleteEventCommands;
using MeetUp.Application.DomainHandlers.Events.Commands.DeleteFavoriteEventCommand;
using MeetUp.Application.DomainHandlers.Events.Commands.HardDeleteEventCommand;
using MeetUp.Application.DomainHandlers.Events.Commands.JoinToEventCommands;
using MeetUp.Application.DomainHandlers.Events.Commands.UpdateEventCommands;
using MeetUp.Application.DomainHandlers.Events.Queries.GetAllEventQuery;
using MeetUp.Application.DomainHandlers.Events.Queries.GetAttendedEventsByUserIdQuery;
using MeetUp.Application.DomainHandlers.Events.Queries.GetEventAttendess;
using MeetUp.Application.DomainHandlers.Events.Queries.GetEventDetail;
using MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByCategoryIdQuery;
using MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByCategoryName;
using MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByTagName;
using MeetUp.Application.DomainHandlers.Events.Queries.GetFavariteEventsQuery;
using MeetUp.Application.DomainHandlers.Events.Queries.GetNonDeletedEvents;
using MeetUp.Application.DomainHandlers.Events.Queries.GetPostedEventsByUserIdQuery;
using MeetUp.Application.DomainHandlers.Events.Queries.SearchEventQuery;
using MeetUp.Application.DomainHandlers.Tags.Queries.GetTags;
using MeetUp.Domain.Entities.Identity;
using MeetUp.Persistence.UtilitiesConcrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MeetUp.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Result>> AddEventAsync([FromBody]CreateEventCommandRequest requestParameters)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            requestParameters.ApplicationUserId= userId;
            await _mediator.Send(requestParameters);
            return Result.Created("creating completed");
        }

        [HttpGet]
        public async Task<ActionResult<Result>> GetAllEventsAsync()
        {
            var items = await _mediator.Send(new GetAllEventsQueryRequest());
            return Result.Ok(items, "Getting all events has been completed with success");
        }

        [HttpGet("byTagName")]
        public async Task<ActionResult<Result>> GetEventsByTagNameAsync([FromQuery]GetEventsByTagNameQueryRequest requestParameters)
        {
            var items = await _mediator.Send(requestParameters);
            return Result.Ok(items, "Getting all events(by Tag name) has been completed with success");
        }
        [HttpGet("nonDeleted")]
        public async Task<ActionResult<Result>> GetEventsNonDeletedAsync()
        {
            var items = await _mediator.Send(new GetNonDeletedEventsQueryRequest());
            return Result.Ok(items, "Getting all non-deleted events has been completed with success");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetEventsWithDetailAsync([FromRoute]int id)
        {
            var item = await _mediator.Send(new GetEventWithDetailQueryRequest()
            {
                EventId = id
            });
            return Result.Ok(item, "Getting event has been completed with success");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> UpdateEventAsync([FromRoute]int id,[FromBody]UpdateEventCommandRequest requestParameters)
        {
            requestParameters.EventId = id;
            await _mediator.Send(requestParameters);
            return Ok();
        }

        [HttpPost("send-comment")]
        public async Task<ActionResult<Result>> AddCommentToEventAsync([FromBody]CreateCommentCommandRequest requestParameters)
        {
            await _mediator.Send(requestParameters);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> DeleteEventAsync([FromRoute]int id)
        {
            await _mediator.Send(new DeleteEventCommandRequest()
            {
                EventId = id,
            });
            return Ok();
        }

        [HttpDelete("hard-delete/{id}")]
        public async Task<ActionResult<Result>> HardDeleteEventAsync([FromRoute]int id)
        {
            await _mediator.Send(new HardDeleteEventCommandRequest()
            {
                EventId = id,
            });
            return Ok();
        }
       
       
       

        [HttpGet("by-category-name")]
        public async Task<ActionResult<Result>> GetEventsByCategoryNameAsync([FromQuery] GetEventsByCategoryNameQueryRequest requestParameters)
        {
            var items = await _mediator.Send(requestParameters);
            return Result.Ok(items, "Getting all events(by Category name) has been completed with success");
        }

        [HttpGet("by-category-id/{id}")]
        public async Task<ActionResult<Result>> GetEventsByCategoryIdAsync([FromRoute] int id)
        {
            var items = await _mediator.Send(new GetEventsByCategoryIdQueryRequest()
            {
                Id = id
            });

            return Result.Ok(items, "Getting all events(by Category id) has been completed with success");
        }
        [HttpGet("search")]
        public async Task<ActionResult<Result>> SearchEventsAsync([FromQuery] SearchEventQueryRequest requestParameters)
        {
            var items = await _mediator.Send(requestParameters);
            return Result.Ok(items, "Searching events has been completed with success");
        }

        

        

        
        
        
    }
}
