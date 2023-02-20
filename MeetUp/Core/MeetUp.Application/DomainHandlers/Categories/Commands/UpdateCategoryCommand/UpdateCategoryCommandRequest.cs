using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
