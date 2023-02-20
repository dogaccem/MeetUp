using MediatR;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Application.DomainHandlers.Tags.ViewModels;
using MeetUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Tags.Queries.GetTags
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQueryRequest, List<TagVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IReadRepository<Tag> _tagReadRepository;
        public GetAllTagsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_tagReadRepository = _unitOfWork.GetReadRepository<Tag>();

        }

        public async Task<List<TagVM>> Handle(GetAllTagsQueryRequest request, CancellationToken cancellationToken)
        {
            var tags = await _unitOfWork.GetReadRepository<Tag>().GetAll(null, null, t => new TagVM()
            {
                Name = t.Name
            });
            return tags;
        }
    }
}
