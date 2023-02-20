using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.DomainHandlers.Tags.Commands.CreateTagCommand
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, Unit>
    {
        public readonly IReadRepository<Event> _readEventRepository;
        public readonly IReadRepository<Tag> _readTagRepository;

        public CreateTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _readEventRepository = unitOfWork.GetReadRepository<Event>();
        }
        public async Task<Unit> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            var eventModel = await _readEventRepository.GetSingle(e => e.Id == request.EventId, e => e.Tags);

            foreach (var tag in request.Tags.Split(','))
            {
                var result = await _readTagRepository.AnyAsync(t => t.Name == tag);
                if (!result) {
                    eventModel.Tags.Add(new Tag()
                    {
                        Name = tag
                    });
                }
                
            }

            return Unit.Value;
        }
    }
}
