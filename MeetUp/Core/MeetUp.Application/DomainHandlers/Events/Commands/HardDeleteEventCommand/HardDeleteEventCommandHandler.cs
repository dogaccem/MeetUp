using MediatR;
using MeetUp.Application.Abstractions;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Commands.HardDeleteEventCommand
{
    public class HardDeleteEventCommandHandler : IRequestHandler<HardDeleteEventCommandRequest, Unit>, ISaveableCommand
    {
        private readonly IWriteRepository<Event> _writeRepository;

        public HardDeleteEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _writeRepository = unitOfWork.GetWriteRepository<Event>();
        }

        public async Task<Unit> Handle(HardDeleteEventCommandRequest request, CancellationToken cancellationToken)
        {

            await _writeRepository.DeleteAsync(request.EventId);
            return Unit.Value;
        }
    }
}
