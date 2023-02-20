using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Events.Commands.JoinToEventCommands
{
    public class JoinToEventCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int ApplicationUserId { get; set; }
        public int EventId { get; set; }
    }
}
