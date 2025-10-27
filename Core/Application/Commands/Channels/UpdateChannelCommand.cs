using AudioWeb.Core.Application.DTOs.Channels;
using MediatR;
 

namespace AudioWeb.Core.Application.Commands.Channels
{
    public record UpdateChannelCommand(int ChannelId, UpdateChannelDto UpdateChannelDto) : IRequest<ChannelDto>
    {
    }
}
