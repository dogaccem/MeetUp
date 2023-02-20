using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.DomainHandlers.Events.Commands.AddEventToFavCommands
{
    public class AddEventToFavCommandHandler : IRequestHandler<AddEventToFavCommandRequest,Unit>
    {
        private readonly IReadRepository<Event> _readRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddEventToFavCommandHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
            _userManager = userManager;
        }
        public async Task<Unit> Handle(AddEventToFavCommandRequest request, CancellationToken cancellationToken)
        {
            var @event = await _readRepository.GetSingle(e => e.Id == request.EventId);

            var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.ApplicationUserId);
            

            currentUser.FavoriteEvents.Add(new FavoriteEvent()
            {
                EventId = @event.Id,
                ApplicationUserId = currentUser.Id
            });

            return Unit.Value;

        }
    }
}
