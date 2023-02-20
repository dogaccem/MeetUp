using MediatR;
using MeetUp.Application.DomainHandlers.Events.Commands.AddEventToFavCommands;
using MeetUp.Application.DomainHandlers.Events.Commands.DeleteFavoriteEventCommand;
using MeetUp.Application.DomainHandlers.Events.Queries.GetFavariteEventsQuery;
using MeetUp.Persistence.UtilitiesConcrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeetUp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteEventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FavoriteEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableCors]
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost("fav/{id}")]
        public async Task<ActionResult<Result>> AddEventToFavAsync([FromRoute] int id)
        {
            await _mediator.Send(new AddEventToFavCommandRequest()
            {
                EventId = id,
                ApplicationUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)

            });
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpGet("user-favs")]
        public async Task<ActionResult<Result>> GetUserFavsAsync()
        {
            var items = await _mediator.Send(new GetAllFavoriteEventsByUserIdQueryRequest()
            {
                ApplicationUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)

            });
            return Ok(items);
        }

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpDelete("delete-fav/{id}")]
        public async Task<ActionResult<Result>> DeleteFavEventAsync([FromRoute] int id)
        {
            await _mediator.Send(new DeleteFavoriteEventCommandRequest()
            {
                UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                EventId = id,
            });
            return Ok();
        }
    }
}
