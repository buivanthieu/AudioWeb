using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Queries.Tracks;
using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class GetAllTracksUploadByChannelserIdHandler : IRequestHandler<GetAllTracksUploadByChannelIdQuery, IEnumerable<TrackDto>>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        public GetAllTracksUploadByChannelserIdHandler(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrackDto>> Handle(GetAllTracksUploadByChannelIdQuery request, CancellationToken cancellationToken = default)
        {
			var tracks = await _trackRepository.GetAllTracksByChannelIdAsync(request.ChannelId);
            return _mapper.Map<IEnumerable<TrackDto>>(tracks);
        }
    }
}
