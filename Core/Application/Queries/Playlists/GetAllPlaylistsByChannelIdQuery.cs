using AudioWeb.Core.Application.DTOs.Playlists;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Playlists
{
    public record GetAllPlaylistsByChannelIdQuery(int ChannelId) : IRequest<IEnumerable<PlaylistDto>>
    {
    }
}
