using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Commands.Playlists;
using AudioWeb.Core.Domain.Interfaces;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class RemoveTrackFromPlaylistHandler : IRequestHandler<RemoveTrackFromPlaylistCommand, bool>
    {
        private readonly IPlaylistItemRepository _playlistItemRepository;
        public RemoveTrackFromPlaylistHandler(IPlaylistItemRepository playlistItemRepository)
        {
            _playlistItemRepository = playlistItemRepository;
        }

        public async Task<bool> Handle(RemoveTrackFromPlaylistCommand request, CancellationToken cancellationToken = default)
        {
			var existingItem = await _playlistItemRepository.GetByPlaylistAndTrackAsync(request.PlaylistId, request.TrackId);
            if (existingItem == null)
            {
                throw new Exception("Track not found in the specified playlist.");
            }
            await _playlistItemRepository.DeleteAsync(existingItem.Id);
            return true;
        }
    }
}
