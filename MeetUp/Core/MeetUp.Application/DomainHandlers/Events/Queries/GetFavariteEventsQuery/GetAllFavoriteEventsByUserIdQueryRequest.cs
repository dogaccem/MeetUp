using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetFavariteEventsQuery
{
    public class GetAllFavoriteEventsByUserIdQueryRequest : IRequest<List<EventVM>>
    {
        public int ApplicationUserId { get; set; }
    }
}
