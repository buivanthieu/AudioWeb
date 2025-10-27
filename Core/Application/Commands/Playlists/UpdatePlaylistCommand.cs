using AudioWeb.Core.Application.DTOs.Playlists;
using MediatR;

namespace AudioWeb.Core.Application.Commands.Playlists
{
    public record UpdatePlaylistCommand (int PlaylistId, UpdatePlaylistDto UpdatePlaylistDto) : IRequest<PlaylistDto>
    {
    }
}
