using MediatR;
using MeetUp.Application.DomainHandlers.AppUsers.Commands.LoginUserCommand;
using MeetUp.Persistence.UtilitiesConcrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Result>> Login([FromBody]LoginUserCommandRequest loginParameters)
        {
            var token = await _mediator.Send(loginParameters);
            return Result.Ok(new
            {
                Token = token,
            });
        }
    }
}
