using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Events.Commands.CreateEventCommands
{
    public class CreateEventCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Capacity { get; set; }
        public string ShortContent { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public int CategoryId { get; set; }
        // event dto end
        public string Content { get; set; }
        public DateTime RespondBy { get; set; } // Deadline
        public DateTime EndDate { get; set; }
        public string Tags { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
