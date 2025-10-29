using System.Threading;
using MediatR;

using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Commands.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class UpdateTrackHandler : IRequestHandler<UpdateTrackCommand, TrackDto>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        public UpdateTrackHandler(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<TrackDto> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
			var existingTrack = await _trackRepository.GetByIdAsync(request.TrackId);
            if (existingTrack == null)
            {
                throw new ArgumentException($"Track with ID {request.TrackId} not found.");
            }
            _mapper.Map(request.UpdateTrackDto, existingTrack);
            var updatedTrack = await _trackRepository.UpdateAsync(existingTrack);
            return _mapper.Map<TrackDto>(updatedTrack);
        }
    }
}
