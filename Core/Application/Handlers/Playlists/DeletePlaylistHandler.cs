using AudioWeb.Core.Application.Commands.Playlists;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.Playlists
{
    public class DeletePlaylistHandler : IRequestHandler<DeletePlaylistCommand, bool>
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public DeletePlaylistHandler(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeletePlaylistCommand request, CancellationToken cancellationToken = default)
        {
            var playlist = await _playlistRepository.GetByIdAsync(request.PlaylistId);
            if (playlist == null)
            {
                throw new Exception("Playlist not found.");
            }
            var result = await _playlistRepository.DeleteAsync(request.PlaylistId);
            return result;
        }
    }
}
