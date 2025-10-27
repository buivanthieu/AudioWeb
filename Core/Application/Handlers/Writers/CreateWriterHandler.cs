using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Application.Commands.Writers;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class CreateWriterHandler : IRequestHandler<CreateWriterCommand, WriterDto>
    {
        public CreateWriterHandler()
        {
        }

        public async Task<WriterDto> Handle(CreateWriterCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
