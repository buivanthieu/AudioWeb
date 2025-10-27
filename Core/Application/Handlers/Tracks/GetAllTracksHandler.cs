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
    public class GetAllTracksHandler : IRequestHandler<GetAllTracksQuery, IEnumerable<TrackDto>>
    {
        public GetAllTracksHandler()
        {
        }

        public async Task<IEnumerable<TrackDto>> Handle(GetAllTracksQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
