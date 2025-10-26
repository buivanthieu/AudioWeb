using AudioWeb.Core.Application.DTOs.Channels;
using MediatR;


namespace AudioWeb.Core.Application.Queries.Channels
{
    public class GetAllChannelsQuery : IRequest<IEnumerable<ChannelDto>>
    {
    }
}
