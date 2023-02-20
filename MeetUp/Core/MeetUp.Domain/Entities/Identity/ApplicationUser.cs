using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<FavoriteEvent>? FavoriteEvents { get; set; } = new List<FavoriteEvent>();
        public List<Event>? Events { get; set; } = new List<Event>();
        public List<AttendedEvent>? AttendedEvents { get; set; } = new List<AttendedEvent>();

    }
}
