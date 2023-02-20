using MeetUp.Domain.Entities.Identity;
using MeetUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels
{
    public class EventWithDetailVM
    {
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Content { get; set; }
        public DateTime RespondByDate { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<FavoriteEvent> FavoriteEvents { get; set; } = new List<FavoriteEvent>();
        public List<AttendedEvent> AttendedEvents { get; set; } = new List<AttendedEvent>();
        public int Capacity { get; set; }
        public string ImageUrl { get; set; }
    }
}
