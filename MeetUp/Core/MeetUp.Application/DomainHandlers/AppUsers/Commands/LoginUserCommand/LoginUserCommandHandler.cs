using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.Authentication;
using MeetUp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace MeetUp.Application.DomainHandlers.AppUsers.Commands.LoginUserCommand
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<string> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(request.Username);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                var token = _jwtTokenService.GenerateAccessToken(request.Username, user.Id);
                return token;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
