using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.Commands.Writers;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class DeleteWriterHandler : IRequestHandler<DeleteWriterCommand, bool>
    {
        public DeleteWriterHandler()
        {
        }

        public async Task<bool> Handle(DeleteWriterCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
