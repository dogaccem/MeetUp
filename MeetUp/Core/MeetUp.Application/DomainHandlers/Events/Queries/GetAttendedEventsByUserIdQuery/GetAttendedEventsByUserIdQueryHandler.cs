using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.Queries.GetFavariteEventsQuery;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities.Identity;
using MeetUp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetAttendedEventsByUserIdQuery
{
    public class GetAttendedEventsByUserIdQueryHandler : IRequestHandler<GetAttendedEventsByUserIdQueryRequest, List<EventVM>>
    {
        private readonly IReadRepository<Event> _readRepository;
        public GetAttendedEventsByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
        }

        public async Task<List<EventVM>> Handle(GetAttendedEventsByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await _readRepository.GetWhere(e => e.IsDeleted == false).Include(e => e.AttendedEvents).ThenInclude(fe => fe.ApplicationUser).ToListAsync();

            var userAttendedEvents = events.Where(e => e.AttendedEvents.Any(fe => fe.ApplicationUserId == request.ApplicationUserId)).Select(e => new EventVM()
            {
                Title = e.Title,
                Place = e.Place,
                ShortContent = e.ShortContent,
                StartDate = e.StartDate,
                CountAttendees = e.AttendedEvents.Count,
                Id = e.Id,
            }).ToList();

            return userAttendedEvents;
        }
    }
}
