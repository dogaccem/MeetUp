using MeetUp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Entities
{
    public class Comment : EntitySoftDeletableIntKey
    {
        public string? Content { get; set; }
        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }
}
