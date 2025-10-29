using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Application.Queries.Playlists;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class GetAllPlaylistsHandler : IRequestHandler<GetAllPlaylistsQuery, IEnumerable<PlaylistDto>>
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public GetAllPlaylistsHandler(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PlaylistDto>> Handle(GetAllPlaylistsQuery request, CancellationToken cancellationToken)
        {
            var playlists = await _playlistRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlaylistDto>>(playlists);
        }
    }
}
