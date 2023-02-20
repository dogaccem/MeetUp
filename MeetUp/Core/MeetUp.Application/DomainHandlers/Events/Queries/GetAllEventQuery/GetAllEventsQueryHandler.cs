using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetAllEventQuery
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQueryRequest, List<EventVM>>
    {
        private readonly IReadRepository<Event> _readRepository;

        public GetAllEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
        }
        public async Task<List<EventVM>> Handle(GetAllEventsQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await _readRepository.GetAll(e=>e.IsDeleted==false, e =>e.AttendedEvents,
                e => new EventVM()
            {
                Title = e.Title,
                ShortContent = e.ShortContent,
                Place = e.Place,
                StartDate = e.StartDate,
                CountAttendees = e.AttendedEvents.Count(),
                Id = e.Id

            });
            return events;
        }
    }
}
