using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.DomainHandlers.Events.Queries.SearchEventQuery
{
    public class SearchEventQueryHandler : IRequestHandler<SearchEventQueryRequest, List<EventVM>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EventVM>> Handle(SearchEventQueryRequest request, CancellationToken cancellationToken)
        {
             
            var filteredEvents = _unitOfWork.GetReadRepository<Event>().GetWhere(e => true);

            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                filteredEvents =
                    filteredEvents.Where(f => f.Category.Name.Contains(request.CategoryName));
            }
            if (!string.IsNullOrEmpty(request.Place))
            {
                filteredEvents =
                    filteredEvents.Where(f => f.Place.Contains(request.Place));
            }
            if (!string.IsNullOrEmpty(request.TagName))
            {
                filteredEvents =
                    filteredEvents.Where(f => f.Tags.Any(t => t.Name.Contains(request.TagName)));
            }
            if (!string.IsNullOrEmpty(request.Title))
            {
                filteredEvents =
                    filteredEvents.Where(f => f.Title.Contains(request.Title));
            }
            if (request.StartDate != null && request.EndDate != null)
            {
            

                filteredEvents =
                    filteredEvents.Where(f=>f.StartDate >= request.StartDate && f.EndDate < request.EndDate.AddDays(1));
            }

            var filteredItems = await filteredEvents.Select(f => new EventVM()
            {
                Title = f.Title,
                CountAttendees = f.AttendedEvents.Count,
                Place = f.Place,
                ShortContent = f.ShortContent,
                StartDate = f.StartDate
            }).ToListAsync(cancellationToken);

            return filteredItems;
        }
    }
}
