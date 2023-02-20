using MeetUp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Domain.Entities
{
    public class Event : EntitySoftDeletableIntKey
    {
        public string Title { get; set; }
        public int Capacity { get; set; }
        public string imageUrl { get; set; }
        public string ShortContent { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventDetailId { get; set; } 
        public EventDetail EventDetail { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Tag>? Tags { get; set; } = new List<Tag>();
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public ApplicationUser? ApplicationUser { get; set; }
        public int? ApplicationUserId { get; set; }
        public List<AttendedEvent>? AttendedEvents { get; set; } = new List<AttendedEvent>();
        public List<FavoriteEvent>? FavoriteEvents { get; set; }

    }
}
