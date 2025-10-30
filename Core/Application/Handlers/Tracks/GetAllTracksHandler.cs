using System.Threading;
using MediatR;

using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Queries.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class GetAllTracksHandler : IRequestHandler<GetAllTracksQuery, IEnumerable<TrackListDto>>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        public GetAllTracksHandler(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrackListDto>> Handle(GetAllTracksQuery request, CancellationToken cancellationToken)
        {
			var tracks = await _trackRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrackListDto>>(tracks);
        }
    }
}
