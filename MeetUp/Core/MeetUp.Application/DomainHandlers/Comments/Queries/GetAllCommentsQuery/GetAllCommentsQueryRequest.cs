using MediatR;
using MeetUp.Application.DomainHandlers.Comments.ViewModels;

namespace MeetUp.Application.DomainHandlers.Comments.Queries.GetAllCommentsQuery
{
    public class GetAllCommentsQueryRequest : IRequest<List<CommentVM>>
    {
    }
}
