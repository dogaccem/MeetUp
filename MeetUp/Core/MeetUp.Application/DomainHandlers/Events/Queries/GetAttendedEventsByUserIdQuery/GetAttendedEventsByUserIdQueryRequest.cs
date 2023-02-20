using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetAttendedEventsByUserIdQuery
{
    public class GetAttendedEventsByUserIdQueryRequest : IRequest<List<EventVM>>
    {
        public int ApplicationUserId { get; set; }
    }
}
