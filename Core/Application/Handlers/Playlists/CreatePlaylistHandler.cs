using AudioWeb.Core.Application.Commands.Playlists;
using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class CreatePlaylistHandler : IRequestHandler<CreatePlaylistCommand, PlaylistDto>
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public CreatePlaylistHandler(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task<PlaylistDto> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken = default)
        {
            var playlistEntity = _mapper.Map<Playlist>(request.CreatePlaylistDto);
            var createdPlaylist = await _playlistRepository.AddAsync(playlistEntity);
            return _mapper.Map<PlaylistDto>(createdPlaylist);
        }
    }
}
