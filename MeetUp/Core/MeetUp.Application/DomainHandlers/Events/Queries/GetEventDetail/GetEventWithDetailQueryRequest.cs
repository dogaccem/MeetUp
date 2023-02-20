using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventDetail
{
    public class GetEventWithDetailQueryRequest : IRequest<EventWithDetailVM>
    {
        public int EventId { get; set; }
    }
}
