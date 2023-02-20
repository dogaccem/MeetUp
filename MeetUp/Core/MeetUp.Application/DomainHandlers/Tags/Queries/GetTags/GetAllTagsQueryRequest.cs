using MediatR;
using MeetUp.Application.DomainHandlers.Tags.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Tags.Queries.GetTags
{
    public class GetAllTagsQueryRequest : IRequest<List<TagVM>>
    {
    }
}
