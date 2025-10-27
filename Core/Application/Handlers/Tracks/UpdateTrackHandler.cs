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
    public class UpdateTrackHandler : IRequestHandler<UpdateTrackCommand, TrackDto>
    {
        public UpdateTrackHandler()
        {
        }

        public async Task<TrackDto> Handle(UpdateTrackCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
