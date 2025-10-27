using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.Commands.Tracks;

namespace AudioWeb.Core.Application.Handlers.Tracks
{
    public class DeleteTrackHandler : IRequestHandler<DeleteTrackCommand, bool>
    {
        public DeleteTrackHandler()
        {
        }

        public async Task<bool> Handle(DeleteTrackCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
