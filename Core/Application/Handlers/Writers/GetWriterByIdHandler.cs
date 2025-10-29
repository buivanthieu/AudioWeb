using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Application.Queries.Writers;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class GetWriterByIdHandler : IRequestHandler<GetWriterByIdQuery, WriterDto>
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;
        public GetWriterByIdHandler(IWriterRepository writerRepository, IMapper mapper)
        {
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        public async Task<WriterDto> Handle(GetWriterByIdQuery request, CancellationToken cancellationToken)
        {
			var writer = await _writerRepository.GetByIdAsync(request.WriterId);
            return _mapper.Map<WriterDto>(writer);
        }
    }
}
