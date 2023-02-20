using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByTagName
{
    public class GetEventsByTagNameQueryHandler : IRequestHandler<GetEventsByTagNameQueryRequest, List<EventVM>>
    {
        //private readonly IEventReadRepository _eventReadRepository;
        //private readonly ReadRepository
        
        private readonly IUnitOfWork _unitOfWork;

        public GetEventsByTagNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EventVM>> Handle(GetEventsByTagNameQueryRequest request, CancellationToken cancellationToken)
        {
            var filteredEventsByTagName = await _unitOfWork.GetReadRepository<Event>().GetAll(e => e.Tags.Any(t=> t.Name == request.Name),
                e => e.Tags,e => new EventVM()
                {
                    Title = e.Title,
                    StartDate= e.StartDate,
                    ShortContent= e.ShortContent,
                    Place = e.Place,
                    Id = e.Id,
                    //CountAttendees = e.Attendees.Count,
                });
            return filteredEventsByTagName;
        }
    }
}
