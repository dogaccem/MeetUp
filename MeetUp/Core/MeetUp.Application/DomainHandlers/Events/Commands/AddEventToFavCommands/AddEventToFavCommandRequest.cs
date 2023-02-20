using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Events.Commands.AddEventToFavCommands
{
    public class AddEventToFavCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int EventId { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
