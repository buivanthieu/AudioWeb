using MediatR;

using AudioWeb.Core.Application.Queries.Channels;
using AudioWeb.Core.Application.DTOs.Channels;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class GetAllChannelsHandler : IRequestHandler<GetAllChannelsQuery, IEnumerable<ChannelDto>>
    {
        public GetAllChannelsHandler()
        {
        }

        public async Task<IEnumerable<ChannelDto>> Handle(GetAllChannelsQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
