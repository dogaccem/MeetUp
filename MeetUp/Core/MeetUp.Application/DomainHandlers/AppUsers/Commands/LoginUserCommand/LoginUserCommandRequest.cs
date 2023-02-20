using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeetUp.Application.DomainHandlers.AppUsers.Commands.LoginUserCommand
{
    public class LoginUserCommandRequest : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
