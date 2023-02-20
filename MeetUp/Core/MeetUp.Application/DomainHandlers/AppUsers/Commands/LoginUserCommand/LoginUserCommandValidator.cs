using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.AppUsers.Commands.LoginUserCommand
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(lu => lu.Username).NotEmpty();
            RuleFor(lu => lu.Password).NotEmpty();
        }
    }
}
