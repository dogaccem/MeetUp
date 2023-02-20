using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetNonDeletedEvents
{
    internal class GetNonDeletedEventsQueryHandler : IRequestHandler<GetNonDeletedEventsQueryRequest, List<EventVM>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNonDeletedEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EventVM>> Handle(GetNonDeletedEventsQueryRequest request, CancellationToken cancellationToken)
        {
            var nonDeletedEvents = await _unitOfWork.GetReadRepository<Event>().GetAll(e => e.IsDeleted == false,e=>e.AttendedEvents,
                e => new EventVM()
                {
                    CountAttendees = e.AttendedEvents.Count,
                    Place = e.Place,
                    ShortContent = e.ShortContent,
                    StartDate = e.StartDate,
                    Title = e.Title,
                    Id = e.Id
                });
            return nonDeletedEvents;
        }
    }
}
