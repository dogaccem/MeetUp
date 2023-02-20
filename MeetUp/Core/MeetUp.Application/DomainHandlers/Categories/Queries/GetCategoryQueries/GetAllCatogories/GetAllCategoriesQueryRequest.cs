using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.DomainHandlers.Categories.ViewModels;

namespace MeetUp.Application.DomainHandlers.Categories.Queries.GetCategoryQueries.GetAllCatogories
{
    public class GetAllCategoriesQueryRequest : IRequest<List<CategoryVM>>
    {
    }
}
