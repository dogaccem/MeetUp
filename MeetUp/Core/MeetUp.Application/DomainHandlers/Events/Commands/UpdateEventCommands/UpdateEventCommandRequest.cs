using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Domain.Entities.Identity;
using MeetUp.Domain.Entities;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Events.Commands.UpdateEventCommands
{
    public class UpdateEventCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Content { get; set; }
        public int Capacity { get; set; }
    }
}
