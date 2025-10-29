using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Commands.Tracks;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class DeleteTrackHandler : IRequestHandler<DeleteTrackCommand, bool>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;
        public DeleteTrackHandler(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _trackRepository.GetByIdAsync(request.TrackId);
            if (track == null)
            {
                throw new ArgumentException($"Track with ID {request.TrackId} not found.");
            }
            var result = await _trackRepository.DeleteAsync(request.TrackId);
            return result;
        }
    }
}
