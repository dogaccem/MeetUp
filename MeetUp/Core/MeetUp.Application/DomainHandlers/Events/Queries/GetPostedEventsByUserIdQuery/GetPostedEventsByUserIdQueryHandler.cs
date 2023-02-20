using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetPostedEventsByUserIdQuery
{
    public class GetPostedEventsByUserIdQueryHandler : IRequestHandler<GetPostedEventsByUserIdQueryRequest, List<EventVM>>
    {
        private readonly IReadRepository<Event> _readRepository;
        public GetPostedEventsByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
        }

        public async Task<List<EventVM>> Handle(GetPostedEventsByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await _readRepository.GetAll<EventVM>(e => e.ApplicationUserId == request.UserId && e.IsDeleted == false, e => e.AttendedEvents, e => new EventVM()
            {
                Title = e.Title,
                Place = e.Place,
                ShortContent = e.ShortContent,
                StartDate = e.StartDate,
                CountAttendees = e.AttendedEvents.Count,
                Id = e.Id,
            });

            return events;
        }
    }
}
