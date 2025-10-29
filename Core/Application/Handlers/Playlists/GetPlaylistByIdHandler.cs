using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Application.Queries.Playlists;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class GetPlaylistByIdHandler : IRequestHandler<GetPlaylistByIdQuery, PlaylistDto>
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public GetPlaylistByIdHandler(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }
        public async Task<PlaylistDto> Handle(GetPlaylistByIdQuery request, CancellationToken cancellationToken)
        {
            var playlist = await _playlistRepository.GetByIdAsync(request.PlaylistId);
            if (playlist == null)
            {
                throw new ArgumentException($"Playlist with ID {request.PlaylistId} not found.");
            }
            return _mapper.Map<PlaylistDto>(playlist);
        }
    }
}
