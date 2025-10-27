using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.Queries.Tracks;
using AudioWeb.Core.Application.DTOs.Tracks;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class GetAllTracksUploadByUserIdHandler : IRequestHandler<GetAllTracksUploadByUserIdQuery, IEnumerable<TrackDto>>
    {
        public GetAllTracksUploadByUserIdHandler()
        {
        }

        public async Task<IEnumerable<TrackDto>> Handle(GetAllTracksUploadByUserIdQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
