using AudioWeb.Core.Application.Commands.Channels;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Core.Domain.Entities;

using AutoMapper;
using MediatR;


namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class CreateChannelHandler : IRequestHandler<CreateChannelCommand, ChannelDto>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;
        public CreateChannelHandler(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task<ChannelDto> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
        {
            var channel = _mapper.Map<Channel>(request.CreateChannelDto);
            var createdChannel = await _channelRepository.AddAsync(channel);
            return _mapper.Map<ChannelDto>(createdChannel);
        }
    }
}
