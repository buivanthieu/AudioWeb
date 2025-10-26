using AudioWeb.Core.Application.DTOs.Channels;
using MediatR;


namespace AudioWeb.Core.Application.Commands.Channels
{
    public class CreateChannelCommand : IRequest<ChannelDto>
    {
    }
}
