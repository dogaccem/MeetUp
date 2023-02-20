using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeetUp.Application.DomainHandlers.Tags.Commands.CreateTagCommand
{
    public class CreateTagCommandRequest : IRequest<Unit>
    {
        public string Tags { get; set; }
        public int EventId { get; set; }
    }
}
