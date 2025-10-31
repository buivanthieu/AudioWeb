using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Queries.Playlists;
using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Domain.Interfaces;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class GetPlaylistsWithTrackHandler : IRequestHandler<GetPlaylistsWithTrackQuery, IEnumerable<PlaylistWithTrackStatusDto>>
    {
        private readonly IPlaylistItemRepository _playlistItemRepository;
        private readonly IPlaylistRepository _playlistRepository;
        public GetPlaylistsWithTrackHandler(IPlaylistItemRepository playlistItemRepository, IPlaylistRepository playlistRepository)
        {
            _playlistItemRepository = playlistItemRepository;
            _playlistRepository = playlistRepository;
        }

        public async Task<IEnumerable<PlaylistWithTrackStatusDto>> Handle(GetPlaylistsWithTrackQuery request, CancellationToken cancellationToken = default)
        {
			var playlists = await _playlistRepository.GetAllPlaylistsByChannelIdAsync(request.ChannelId);
            var result = playlists.Select(playlist => new PlaylistWithTrackStatusDto
            {
                PlaylistId = playlist.Id,
                Title = playlist.Title,
                Description = playlist.Description,
                ContainsTrack = playlist.PlaylistItems.Any(item => item.PlaylistId == playlist.Id)
            });
            return result;
        }
    }
}
