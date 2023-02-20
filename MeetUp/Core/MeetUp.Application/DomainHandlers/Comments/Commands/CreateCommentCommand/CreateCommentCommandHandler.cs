using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Entities;

namespace MeetUp.Application.DomainHandlers.Comments.Commands.CreateCommentCommand
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var @event = await _unitOfWork.GetReadRepository<Event>().GetSingle(
                ed => ed.Id == request.EventId,
                ed => ed.Comments);

            @event.Comments.Add(new Comment()
            {
                Content = request.Content
            });

            return Unit.Value;
        }
    }
}
