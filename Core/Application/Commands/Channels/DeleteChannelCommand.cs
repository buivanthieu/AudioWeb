using MediatR;
 

namespace AudioWeb.Core.Application.Commands.Channels
{
    public record DeleteChannelCommand (int ChannelId) : IRequest<bool>
    {
    }
}
