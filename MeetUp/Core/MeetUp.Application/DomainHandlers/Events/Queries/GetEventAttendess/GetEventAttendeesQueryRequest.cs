using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels;
using MeetUp.Domain.Entities;
using MeetUp.Domain.Entities.Identity;

namespace MeetUp.Application.DomainHandlers.Events.Queries.GetEventAttendess
{
    public class GetEventAttendeesQueryRequest : IRequest<List<ApplicationUser>>
    {
        public int EventId  { get; set; }
    }
}
