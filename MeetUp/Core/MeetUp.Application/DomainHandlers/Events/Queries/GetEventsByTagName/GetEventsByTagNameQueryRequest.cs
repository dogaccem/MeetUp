using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByTagName
{
    public class GetEventsByTagNameQueryRequest : IRequest<List<EventVM>>
    {
        public string Name { get; set; }
    }
}
