using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Application.Queries.Writers;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class GetWriterByIdHandler : IRequestHandler<GetWriterByIdQuery, WriterDto>
    {
        public GetWriterByIdHandler()
        {
        }

        public async Task<WriterDto> Handle(GetWriterByIdQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
