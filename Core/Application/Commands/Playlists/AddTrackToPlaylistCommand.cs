using MediatR;


namespace AudioWeb.Core.Application.Commands.Playlists
{
    public record AddTrackToPlaylistCommand (int PlaylistId, int TrackId) : IRequest<bool>
    {
    }
}
