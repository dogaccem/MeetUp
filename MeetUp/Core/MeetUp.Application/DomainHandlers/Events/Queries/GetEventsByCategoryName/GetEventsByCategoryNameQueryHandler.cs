using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventsByCategoryName
{
    public class GetEventsByCategoryNameQueryHandler : IRequestHandler<GetEventsByCategoryNameQueryRequest, List<EventVM>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventsByCategoryNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EventVM>> Handle(GetEventsByCategoryNameQueryRequest request, CancellationToken cancellationToken)
        {
            var filteredByCategoryName = await _unitOfWork.GetReadRepository<Event>().GetAll(e => e.Category.Name == request.CategoryName, e => e.Category,
            e=> new EventVM()
            {
                CountAttendees = e.AttendedEvents.Count,
                Place = e.Place,
                ShortContent= e.ShortContent,
                StartDate= e.StartDate,
                Title = e.Title,
                Id = e.Id
            });

            return filteredByCategoryName;
        }
    }
}
