using System.Threading;
using MediatR;

using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Queries.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class GetTrackByIdHandler : IRequestHandler<GetTrackByIdQuery, TrackDto>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        public GetTrackByIdHandler(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<TrackDto> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
			var track = await _trackRepository.GetByIdAsync(request.TrackId);
            if (track == null)
            {
                throw new ArgumentException($"Track with ID {request.TrackId} not found.");
            }
            return _mapper.Map<TrackDto>(track);
        }
    }
}
