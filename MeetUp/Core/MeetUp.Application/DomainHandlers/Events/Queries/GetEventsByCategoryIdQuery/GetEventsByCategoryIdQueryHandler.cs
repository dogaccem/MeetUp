using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByCategoryIdQuery
{
    public class GetEventsByCategoryIdQueryHandler : IRequestHandler<GetEventsByCategoryIdQueryRequest, List<EventVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEventsByCategoryIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EventVM>> Handle(GetEventsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var filteredEventsByCategoryId = await _unitOfWork.GetReadRepository<Event>().GetAll<EventVM>(e => e.CategoryId == request.Id && e.IsDeleted == false, e => e.EventDetail,
                e => new EventVM()
                {
                    CountAttendees= e.AttendedEvents.Count,
                    Place = e.Place,
                    ShortContent= e.ShortContent,
                    StartDate= e.StartDate,
                    Title= e.Title,
                    Id = e.Id,
                });

            return filteredEventsByCategoryId;
        }
    }
}
