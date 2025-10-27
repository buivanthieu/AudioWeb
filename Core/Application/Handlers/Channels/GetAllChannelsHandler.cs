using MediatR;

using AudioWeb.Core.Application.Queries.Channels;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class GetAllChannelsHandler : IRequestHandler<GetAllChannelsQuery, IEnumerable<ChannelDto>>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;
        public GetAllChannelsHandler(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChannelDto>> Handle(GetAllChannelsQuery request, CancellationToken cancellationToken = default)
        {
			var channels = await _channelRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ChannelDto>>(channels);
        }
    }
}
