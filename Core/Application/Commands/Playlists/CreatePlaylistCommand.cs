using AudioWeb.Core.Application.DTOs.Playlists;
using MediatR;

namespace AudioWeb.Core.Application.Commands.Playlists
{
    public record CreatePlaylistCommand(CreatePlaylistDto CreatePlaylistDto) : IRequest<PlaylistDto>
    {
    }
}
