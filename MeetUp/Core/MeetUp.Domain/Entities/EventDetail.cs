using MeetUp.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domain.Abstractions;

namespace MeetUp.Domain.Entities
{
    public class EventDetail : EntitySoftDeletableIntKey
    { 
        public string Content { get; set; }
        public DateTime RespondBy { get; set; }
        public TimeSpan IntervalTime { get; set; }
        
    }
}
