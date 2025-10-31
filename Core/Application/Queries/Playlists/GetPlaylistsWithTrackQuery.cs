using AudioWeb.Core.Application.DTOs.Playlists;
using MediatR;


namespace AudioWeb.Core.Application.Queries.Playlists
{
    public record GetPlaylistsWithTrackQuery(int ChannelId) : IRequest<IEnumerable<PlaylistWithTrackStatusDto>>
    {
    }
}
