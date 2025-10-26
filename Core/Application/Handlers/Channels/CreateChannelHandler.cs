using AudioWeb.Core.Application.Commands.Channels;
using AudioWeb.Core.Application.DTOs.Channels;
using MediatR;


namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class CreateChannelHandler : IRequestHandler<CreateChannelCommand, ChannelDto>
    {
        public CreateChannelHandler()
        {
        }

        public async Task<ChannelDto> Handle(CreateChannelCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
