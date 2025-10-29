using AudioWeb.Core.Application.Commands.Channels;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class DeleteChannelHandler : IRequestHandler<DeleteChannelCommand, bool>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;
        public DeleteChannelHandler(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteChannelCommand request, CancellationToken cancellationToken)
        {
			var channel = await _channelRepository.GetByIdAsync(request.ChannelId);
            if (channel == null)
            {
                throw new Exception("Channel not found.");
            }
            var result = await _channelRepository.DeleteAsync(request.ChannelId);
            return result;
        }
    }
}
