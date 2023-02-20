using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Categories.ViewModels;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Categories.Queries.GetCategoryQueries.GetAllCatogories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<CategoryVM>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CategoryVM>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.GetReadRepository<Category>().GetAll(null, c => c.Events, c =>
                new CategoryVM()
                {
                    Id = c.Id,
                    Name = c.Name,
                    EventCount = c.Events.Count()
                });

            return categories;
        }
    }
}
