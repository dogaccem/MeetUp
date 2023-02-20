using MediatR;
using MeetUp.Application.DomainHandlers.AppUsers.Commands.CreateUserCommand;
using MeetUp.Application.DomainHandlers.AppUsers.Queries.GetUserByIdQuery;
using MeetUp.Application.DomainHandlers.Events.Queries.GetPostedEventsByUserIdQuery;
using MeetUp.Persistence.UtilitiesConcrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeetUp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserCommandRequest requestParameters)
        {
            await _mediator.Send(requestParameters);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpGet("user-posted")]
        public async Task<ActionResult<Result>> GetUserPostedEventsAsync()
        {
            var items = await _mediator.Send(new GetPostedEventsByUserIdQueryRequest()
            {
                UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)

            });
            return Ok(items);
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateUserAsync()
        //{
        //    return Ok();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteUserAsync()
        //{
        //    return Ok();
        //}

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpGet]
        public async Task<ActionResult<Result>> GetUserByIdAsync()
        {
            var user = await _mediator.Send(new GetUserByIdQueryRequest()
            {
                UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
            });
            return Ok(user);
        }

        //[HttpGet("by-name")]
        //public async Task<IActionResult> GetUserByNameAsync()
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetUsersAsync()
        //{
        //    return Ok();
        //}

    }
}
