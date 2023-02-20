using MediatR;
using MeetUp.Domain.Entities.Identity;

namespace MeetUp.Application.DomainHandlers.AppUsers.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryRequest : IRequest<ApplicationUser>
    {
        public int UserId { get; set; }
    }
}
