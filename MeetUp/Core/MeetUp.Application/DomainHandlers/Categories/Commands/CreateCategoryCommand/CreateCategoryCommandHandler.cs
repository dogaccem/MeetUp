using MediatR;
using MeetUp.Application.Abstractions;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetWriteRepository<Category>().AddAsync(new Category()
            {
                Name = request.Name,
            });
            return Unit.Value;
        }
    }
}
