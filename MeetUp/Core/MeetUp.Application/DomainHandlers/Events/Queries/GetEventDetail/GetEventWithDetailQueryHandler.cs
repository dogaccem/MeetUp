using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventDetail
{
    public class GetEventWithDetailQueryHandler : IRequestHandler<GetEventWithDetailQueryRequest, EventWithDetailVM>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventWithDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EventWithDetailVM> Handle(GetEventWithDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var eventWithDetail = await _unitOfWork.GetReadRepository<Event>().GetSingle(e => e.Id == request.EventId && e.IsDeleted == false,
                e=>e.EventDetail, e => e.Comments, e => e.AttendedEvents, e => e.FavoriteEvents);

            return new EventWithDetailVM()
            {
                Title = eventWithDetail.Title,
                Content = eventWithDetail.EventDetail.Content,
                Comments = eventWithDetail.Comments,
                AttendedEvents = eventWithDetail.AttendedEvents,
                StartDate = eventWithDetail.StartDate,
                EndDate = eventWithDetail.EndDate,
                Place = eventWithDetail.Place,
                RespondByDate = eventWithDetail.EventDetail.RespondBy,
                FavoriteEvents = eventWithDetail.FavoriteEvents,
                Capacity= eventWithDetail.Capacity,
                ImageUrl = eventWithDetail.imageUrl,
            };
        }
    }
}
