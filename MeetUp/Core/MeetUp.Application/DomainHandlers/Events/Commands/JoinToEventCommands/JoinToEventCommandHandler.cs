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
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.DomainHandlers.Events.Commands.JoinToEventCommands
{
    public class JoinToEventCommandHandler : IRequestHandler<JoinToEventCommandRequest,Unit>
    {
        private readonly IReadRepository<Event> _readRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public JoinToEventCommandHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
            _userManager = userManager;
        }
        public async Task<Unit> Handle(JoinToEventCommandRequest request, CancellationToken cancellationToken)
        {
            var @event = await _readRepository.GetSingle(e => e.Id == request.EventId,e=> e.AttendedEvents);
          
            if (@event?.AttendedEvents?.Count < @event?.Capacity) 
            {
                @event.AttendedEvents.Add(new AttendedEvent()
                {
                    EventId = @event.Id,
                    ApplicationUserId = request.ApplicationUserId
                });
            }
           


            return Unit.Value;
        }
    }
}
