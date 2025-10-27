using System.Threading;
using MediatR;

using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.Queries.Tags;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
    {
        public GetAllTagsHandler()
        {
        }

        public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
