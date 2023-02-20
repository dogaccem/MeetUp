using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetFavariteEventsQuery
{
    public class GetAllFavoriteEventsByUserIdQueryHandler : IRequestHandler<GetAllFavoriteEventsByUserIdQueryRequest, List<EventVM>>
    {
        private readonly IReadRepository<Event> _readRepository;
        public GetAllFavoriteEventsByUserIdQueryHandler( IUnitOfWork unitOfWork)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
        }

        public async Task<List<EventVM>> Handle(GetAllFavoriteEventsByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await _readRepository.GetWhere(e => e.IsDeleted == false).Include(e=>e.FavoriteEvents).ThenInclude(fe=>fe.ApplicationUser).ToListAsync();

            var userFavoriteEvents = events.Where(e => e.FavoriteEvents.Any(fe => fe.ApplicationUserId == request.ApplicationUserId)).Select(e => new EventVM()
            {
                Title = e.Title,
                Place = e.Place,
                ShortContent = e.ShortContent,
                StartDate = e.StartDate,
                CountAttendees = e.AttendedEvents.Count,
                Id = e.Id,
            }).ToList();  

            return userFavoriteEvents;
        }
    }
}
