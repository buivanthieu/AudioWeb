using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Commands.Tracks;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class CreateTrackHandler : IRequestHandler<CreateTrackCommand, TrackDto>
    {
        public CreateTrackHandler()
        {
        }

        public async Task<TrackDto> Handle(CreateTrackCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
