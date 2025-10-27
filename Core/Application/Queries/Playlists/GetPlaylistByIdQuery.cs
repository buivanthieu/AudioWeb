using AudioWeb.Core.Application.DTOs.Playlists;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Playlists
{
    public record GetPlaylistByIdQuery(int PlaylistId) : IRequest<PlaylistDto>
    {
    }
}
