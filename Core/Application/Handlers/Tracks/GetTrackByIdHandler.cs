using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Application.Queries.Tracks;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class GetTrackByIdHandler : IRequestHandler<GetTrackByIdQuery, TrackDto>
    {
        public GetTrackByIdHandler()
        {
        }

        public async Task<TrackDto> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
