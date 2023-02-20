
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Comments.Commands.CreateCommentCommand
{
    public class CreateCommentCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public string Content { get; set; }
        public int EventId { get; set; }

    }
}
