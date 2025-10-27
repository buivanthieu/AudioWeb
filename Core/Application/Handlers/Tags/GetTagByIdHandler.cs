using MediatR;

using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.Queries.Tags;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, TagDto>
    {
        public GetTagByIdHandler()
        {
        }

        public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
