using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Events.Commands.UpdateEventCommands
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommandRequest, Unit>
    {
        private readonly IReadRepository<Event> _readRepository;
        private readonly IWriteRepository<Event> _writeRepository;
        public UpdateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
            _writeRepository = unitOfWork.GetWriteRepository<Event>();
        }
        public async Task<Unit> Handle(UpdateEventCommandRequest request, CancellationToken cancellationToken)
        {
            var eventWithDetail = await _readRepository
                .GetSingle(e => e.Id == request.EventId, e => e.EventDetail);

           
                eventWithDetail.Title = request.Title;
                eventWithDetail.Place = request.Place;
                eventWithDetail.CategoryId = request.CategoryId;
                eventWithDetail.StartDate = request.StartDate;
                eventWithDetail.EndDate = request.EndDate;
            eventWithDetail.Capacity = request.Capacity;
                eventWithDetail.EventDetail.Content = request.Content;

                await _writeRepository.UpdateAsync(eventWithDetail);
                

            return Unit.Value;
        }
    }
}
