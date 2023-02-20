using MeetUp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Entities
{
    public class Category : EntitySoftDeletableIntKey
    {
        public string Name { get; set; }
        public List<Event>? Events { get; set; } = new List<Event>();
    }
}
