using MediatR;
using MeetUp.Application.DomainHandlers.Tags.Queries.GetTags;
using MeetUp.Persistence.UtilitiesConcrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("tags")]
        public async Task<ActionResult<Result>> GetAllTagsAsync()
        {
            var items = await _mediator.Send(new GetAllTagsQueryRequest());
            return Result.Ok(items, "Getting all tags has been completed with success");
        }
    }
}
