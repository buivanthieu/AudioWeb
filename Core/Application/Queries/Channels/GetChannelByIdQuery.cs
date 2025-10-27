using AudioWeb.Core.Application.DTOs.Channels;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Channels
{
    public record GetChannelByIdQuery(int ChannelId) : IRequest<ChannelDto>
    {
    }
}
