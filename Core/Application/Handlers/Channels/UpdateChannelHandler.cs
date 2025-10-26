using MediatR;

using AudioWeb.Core.Application.Commands.Channels;
using AudioWeb.Core.Application.DTOs.Channels;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class UpdateChannelHandler : IRequestHandler<UpdateChannelCommand, ChannelDto>
    {
        public UpdateChannelHandler()
        {
        }

        public async Task<ChannelDto> Handle(UpdateChannelCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
