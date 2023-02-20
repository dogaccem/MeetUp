using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Categories.ViewModels;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Categories.Queries.GetCategoryQueries.GetNonDeletedCatogoriesQueries
{
    public class GetNonDeletedCategoriesQueryHandler : IRequestHandler<GetNonDeletedCategoriesQueryRequest, List<CategoryVM>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNonDeletedCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CategoryVM>> Handle(GetNonDeletedCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var nonDeletedCategories = await _unitOfWork.GetReadRepository<Category>().GetAll(c => c.IsDeleted == false,
                c => c.Events, c => new CategoryVM()
                {
                    Name = c.Name,
                    EventCount = c.Events.Count
                });

            return nonDeletedCategories;
        }
    }
}
