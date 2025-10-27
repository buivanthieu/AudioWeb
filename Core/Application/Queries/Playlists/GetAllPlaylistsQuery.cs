using AudioWeb.Core.Application.DTOs.Playlists;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Playlists
{
    public record GetAllPlaylistsQuery() : IRequest<IEnumerable<PlaylistDto>>
    {
    }
}
