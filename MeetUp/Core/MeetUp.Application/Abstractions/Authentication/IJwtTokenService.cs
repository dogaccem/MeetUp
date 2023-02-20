using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.Abstractions.Authentication
{
    public interface IJwtTokenService
    {
        public string GenerateAccessToken(string username, int userId);
    }
}
