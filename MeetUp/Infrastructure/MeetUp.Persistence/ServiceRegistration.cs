using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities.Identity;
using MeetUp.Persistence.Contexts;
using MeetUp.Persistence.Repositories;
using MeetUp.Persistence.UnitOfWorkConcrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            //services.AddDbContext<MeetUpAppDbContext>(options => options.UseSqlServer(@"Server=TR-ADN-FHJ9TT2;
            //                                          Database=MeetUpDb;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;"));

            services.AddDbContext<MeetUpAppDbContext>(options => options.UseSqlServer(@"Server=localhost,1433;Database=MeetUpDb;User Id=SA;Password=yourStrong(!)Password;MultipleActiveResultSets=true;Encrypt=False"));

            

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters =
                    @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<MeetUpAppDbContext>();
            //kaldır
           

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
