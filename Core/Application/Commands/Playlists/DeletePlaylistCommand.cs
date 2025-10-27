using MediatR;

namespace AudioWeb.Core.Application.Commands.Playlists
{
    public record DeletePlaylistCommand(int PlaylistId) : IRequest<bool>
    {
    }
}
