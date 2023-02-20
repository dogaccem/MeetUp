using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventAttendess
{
    public class GetEventAttendeesQueryHandler : IRequestHandler<GetEventAttendeesQueryRequest, List<ApplicationUser>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetEventAttendeesQueryHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<List<ApplicationUser>> Handle(GetEventAttendeesQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Include(u => u.AttendedEvents)
                .ThenInclude(at => at.Event).ToListAsync();

            var attendess = users.Where(u => u.AttendedEvents
                .Any(at => at.EventId == request.EventId)).ToList();

            return attendess;
        }
    }
}
