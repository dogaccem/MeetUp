using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.SearchEventQuery
{
    public class SearchEventQueryValidator : AbstractValidator<SearchEventQueryRequest>
    {
        public SearchEventQueryValidator()
        {
            
        }
    }
}
