using AudioWeb.Core.Application.Commands.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioWeb.Core.Application.Handlers.Channels
{
    public class DeleteChannelHandler : IRequestHandler<DeleteChannelCommand, bool>
    {
        public DeleteChannelHandler()
        {
        }

        public async Task<bool> Handle(DeleteChannelCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
