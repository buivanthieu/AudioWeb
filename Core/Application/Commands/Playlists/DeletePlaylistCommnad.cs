using MediatR;

namespace AudioWeb.Core.Application.Commands.Playlists
{
    public record DeletePlaylistCommnad(int PlaylistId) : IRequest<bool>
    {
    }
}
