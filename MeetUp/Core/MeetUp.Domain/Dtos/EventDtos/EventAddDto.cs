using MeetUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Dtos.EventDtos
{
    public class EventAddDto
    {
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Place { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public int CategoryId { get; set; }
        // event dto end
        public string Content { get; set; }
        public DateOnly RespondByDate { get; set; } // Deadline
        public TimeOnly RespondByTime { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
