using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Commands.Playlists;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class AddTrackToPlaylistHandler : IRequestHandler<AddTrackToPlaylistCommand, bool>
    {
        private readonly IPlaylistItemRepository _playlistItemRepository;
        
        public AddTrackToPlaylistHandler(IPlaylistItemRepository playlistItemRepository)
        {
            _playlistItemRepository = playlistItemRepository;
        }

        public async Task<bool> Handle(AddTrackToPlaylistCommand request, CancellationToken cancellationToken = default)
        {
            var existingItem = await _playlistItemRepository.GetByPlaylistAndTrackAsync(request.PlaylistId, request.TrackId);
            if (existingItem != null)
            {
                return false;
            }
            var playlistItem = new PlaylistItem
            {
                PlaylistId = request.PlaylistId,
                TrackId = request.TrackId,
                AddedAt = DateTime.UtcNow
            };
            await _playlistItemRepository.AddAsync(playlistItem);
            return true;



        }
    }
}
