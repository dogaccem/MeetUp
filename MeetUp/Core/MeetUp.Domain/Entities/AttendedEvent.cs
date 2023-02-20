using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domain.Abstractions;
using MeetUp.Domain.Entities.Identity;

namespace MeetUp.Domain.Entities
{
    public class AttendedEvent
    {
        public int? EventId;

        public Event? Event;
        public int? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
