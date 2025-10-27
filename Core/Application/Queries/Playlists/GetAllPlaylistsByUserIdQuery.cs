using AudioWeb.Core.Application.DTOs.Playlists;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Playlists
{
    public record GetAllPlaylistsByUserIdQuery(int UserId) : IRequest<IEnumerable<PlaylistDto>>
    {
    }
}
