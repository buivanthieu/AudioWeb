using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Application.Queries.Playlists;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class GetAllPlaylistsByChannelIdHandler : IRequestHandler<GetAllPlaylistsByChannelIdQuery, IEnumerable<PlaylistDto>>
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public GetAllPlaylistsByChannelIdHandler(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PlaylistDto>> Handle(GetAllPlaylistsByChannelIdQuery request, CancellationToken cancellationToken = default)
        {
            var playlists = await _playlistRepository.GetAllByChannelIdAsync(request.ChannelId);
            return _mapper.Map<IEnumerable<PlaylistDto>>(playlists);
        }
    }
}
