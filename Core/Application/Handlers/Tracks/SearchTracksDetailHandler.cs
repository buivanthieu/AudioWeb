using System.Threading;
using MediatR;

using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Queries.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class SearchTracksDetailHandler : IRequestHandler<SearchTracksDetailQuery, IEnumerable<TrackListDto>>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        public SearchTracksDetailHandler(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrackListDto>> Handle(SearchTracksDetailQuery request, CancellationToken cancellationToken = default)
        {
			var tracks = _trackRepository.SearchTracksDetailAsync(
                request.SearchTerm,
                request.CategoryId,
                request.TagIds,
                request.SortBy,
                request.SortOrder
            );
            return _mapper.Map<IEnumerable<TrackListDto>>(await tracks);
        }
    }
}
