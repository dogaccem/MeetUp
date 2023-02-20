using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            
            var category = await _unitOfWork.GetReadRepository<Category>().GetSingle(c => c.Id == request.CategoryId);
            category.IsDeleted = true;
            
            await _unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);
                
            
           

            return Unit.Value;
            
        }
    }
}
