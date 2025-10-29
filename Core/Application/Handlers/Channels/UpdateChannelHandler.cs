using MediatR;

using AudioWeb.Core.Application.Commands.Channels;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class UpdateChannelHandler : IRequestHandler<UpdateChannelCommand, ChannelDto>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;
        public UpdateChannelHandler(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task<ChannelDto> Handle(UpdateChannelCommand request, CancellationToken cancellationToken)
        {
			var existingChannel = await _channelRepository.GetByIdAsync(request.ChannelId);
            if (existingChannel == null)
            {
                throw new KeyNotFoundException($"Channel with ID {request.ChannelId} not found.");
            }
            _mapper.Map(request.UpdateChannelDto, existingChannel);
            var updatedChannel = await _channelRepository.UpdateAsync(existingChannel);
            return _mapper.Map<ChannelDto>(updatedChannel);
        }
    }
}
