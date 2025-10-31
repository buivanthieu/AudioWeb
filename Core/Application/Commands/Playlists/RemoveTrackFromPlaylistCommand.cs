using MediatR;

namespace AudioWeb.Core.Application.Commands.Playlists
{
    public record RemoveTrackFromPlaylistCommand(int PlaylistId, int TrackId) : IRequest<bool>
    {
    }
}
