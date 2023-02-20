using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Queries.SearchEventQuery
{
    public class SearchEventQueryRequest : IRequest<List<EventVM>>
    {
        public string? Place { get; set; }
        public string? TagName { get; set; }
        public string? CategoryName { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
