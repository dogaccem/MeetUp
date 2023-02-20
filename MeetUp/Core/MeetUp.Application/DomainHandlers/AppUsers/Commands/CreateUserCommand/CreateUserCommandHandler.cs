using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace MeetUp.Application.DomainHandlers.AppUsers.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userManager.CreateAsync(new ApplicationUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Username
            }, request.Password);

            return Unit.Value;
        }
    }
}
