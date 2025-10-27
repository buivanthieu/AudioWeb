using AudioWeb.Core.Application.DTOs.Channels;
using MediatR;


namespace AudioWeb.Core.Application.Commands.Channels
{
    public record CreateChannelCommand(CreateChannelDto CreateChannelDto) : IRequest<ChannelDto>
    {
    }
}
