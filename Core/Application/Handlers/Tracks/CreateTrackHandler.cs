using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Commands.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class CreateTrackHandler : IRequestHandler<CreateTrackCommand, TrackDto>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        public CreateTrackHandler(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<TrackDto> Handle(CreateTrackCommand request, CancellationToken cancellationToken = default)
        {
			var track = _mapper.Map<Track>(request.CreateTrackDto);
            var createdTrack = await _trackRepository.AddAsync(track);
            return _mapper.Map<TrackDto>(createdTrack);
        }
    }
}
