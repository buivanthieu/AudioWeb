using MediatR;

using AudioWeb.Core.Application.Queries.Channels;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class GetChannelByIdHandler : IRequestHandler<GetChannelByIdQuery, ChannelDto>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;
        public GetChannelByIdHandler(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task<ChannelDto> Handle(GetChannelByIdQuery request, CancellationToken cancellationToken = default)
        {
			var channel = await _channelRepository.GetByIdAsync(request.ChannelId);
            return _mapper.Map<ChannelDto>(channel);
        }
    }
}
