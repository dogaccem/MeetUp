using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Events.Commands.DeleteEventCommands
{
    public class DeleteEventCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int EventId { get; set; }
    }
}
