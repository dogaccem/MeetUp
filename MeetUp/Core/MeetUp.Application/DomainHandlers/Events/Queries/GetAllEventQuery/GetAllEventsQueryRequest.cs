using MediatR;
using MeetUp.Application.Abstractions.Caching;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetAllEventQuery
{
    public class GetAllEventsQueryRequest : IRequest<List<EventVM>>, ICacheableMediatrQuery
    {
        public string CacheKey => "EventList";
        
    }
    
}
