using MediatR;
using MeetUp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Commands.DeleteFavoriteEventCommand
{
    public class DeleteFavoriteEventCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
