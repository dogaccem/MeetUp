using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MeetUp.Application.DomainHandlers.Events.Commands.CreateEventCommands
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommandRequest>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(e => e.Title).NotEmpty();
        }
    }
}
