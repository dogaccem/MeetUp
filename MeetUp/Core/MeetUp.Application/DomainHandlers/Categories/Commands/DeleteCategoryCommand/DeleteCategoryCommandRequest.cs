using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int CategoryId { get; set; }
    }
}
