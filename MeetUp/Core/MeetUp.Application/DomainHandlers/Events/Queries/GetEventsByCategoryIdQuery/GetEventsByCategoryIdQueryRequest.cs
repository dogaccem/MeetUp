using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByCategoryIdQuery
{
    public class GetEventsByCategoryIdQueryRequest : IRequest<List<EventVM>>
    {
        public int Id { get; set; }
    }
}
