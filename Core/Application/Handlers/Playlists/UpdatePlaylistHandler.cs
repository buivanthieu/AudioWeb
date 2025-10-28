using AudioWeb.Core.Application.Commands.Playlists;
using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class UpdatePlaylistHandler : IRequestHandler<UpdatePlaylistCommand, PlaylistDto>
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public UpdatePlaylistHandler(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task<PlaylistDto> Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken = default)
        {
            var playlist = await _playlistRepository.GetByIdAsync(request.PlaylistId);
            if (playlist == null)
            {
                throw new Exception("Playlist item not found.");
            }
            
            _mapper.Map(request.UpdatePlaylistDto, playlist);
            var updatedPlaylist = await _playlistRepository.UpdateAsync(playlist);
            return _mapper.Map<PlaylistDto>(updatedPlaylist);
        }
    }
}
