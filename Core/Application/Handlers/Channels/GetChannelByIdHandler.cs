using MediatR;

using AudioWeb.Core.Application.Queries.Channels;
using AudioWeb.Core.Application.DTOs.Channels;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class GetChannelByIdHandler : IRequestHandler<GetChannelByIdQuery, ChannelDto>
    {
        public GetChannelByIdHandler()
        {
        }

        public async Task<ChannelDto> Handle(GetChannelByIdQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
