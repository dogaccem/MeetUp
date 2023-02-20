using MediatR;
using MeetUp.Application.Abstractions;

namespace MeetUp.Application.DomainHandlers.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public string Name { get; set; }
    }
}
