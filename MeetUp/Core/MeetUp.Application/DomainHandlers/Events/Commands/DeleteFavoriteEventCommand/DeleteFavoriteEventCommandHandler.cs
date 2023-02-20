using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Commands.DeleteFavoriteEventCommand
{
    public class DeleteFavoriteEventCommandHandler : IRequestHandler<DeleteFavoriteEventCommandRequest, Unit>
    {
        private readonly IReadRepository<Event> _readRepository;
        private readonly IWriteRepository<Event> _writeRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public DeleteFavoriteEventCommandHandler(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
            _readRepository = unitOfWork.GetReadRepository<Event>();
            _writeRepository= unitOfWork.GetWriteRepository<Event>();
            _userManager = userManager;
            

        }
        public async Task<Unit> Handle(DeleteFavoriteEventCommandRequest request, CancellationToken cancellationToken)
        {
            
            var currentUser = await _userManager.Users.Include(u=>u.FavoriteEvents).ThenInclude(fe=>fe.Event).FirstOrDefaultAsync(u=>u.Id== request.UserId);
            var @event = currentUser.FavoriteEvents.FirstOrDefault(e=>e.EventId==request.EventId);
            currentUser.FavoriteEvents.Remove(@event);
            return Unit.Value;
        }
    }
}
