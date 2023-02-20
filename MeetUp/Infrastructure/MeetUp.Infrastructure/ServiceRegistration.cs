using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Application.Abstractions.Authentication;
using MeetUp.Infrastructure.Concrete.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtTokenService, JwtTokenService>();
        }
    }
}
