using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Events.Commands.DeleteEventCommands
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommandRequest, Unit>
    {
        private readonly IReadRepository<Event> _readRepository;
        private readonly IWriteRepository<Event> _writeRepository;

        public DeleteEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
            _writeRepository= unitOfWork.GetWriteRepository<Event>();
        }
        public async Task<Unit> Handle(DeleteEventCommandRequest request, CancellationToken cancellationToken)
        {
            var @event = await _readRepository
                .GetSingle(e => e.Id == request.EventId, e => e.EventDetail);
            @event.IsDeleted= true;
            await _writeRepository.UpdateAsync(@event);
            return Unit.Value;

            
        }
    }
}
