using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Categories.ViewModels;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Categories.Queries.GetCategoryQueries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest,CategoryVM>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CategoryVM> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.GetReadRepository<Category>().GetSingle(
                c => c.Id == request.CategoryId,
                c => c.Events, c => new CategoryVM()
                {
                    Name = c.Name,
                    EventCount = c.Events.Count,
                });

            return category;
        }
    }
}
