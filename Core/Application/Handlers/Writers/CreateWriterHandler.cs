using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Application.Commands.Writers;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class CreateWriterHandler : IRequestHandler<CreateWriterCommand, WriterDto>
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;
        public CreateWriterHandler(IWriterRepository writerRepository, IMapper mapper)
        {
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        public async Task<WriterDto> Handle(CreateWriterCommand request, CancellationToken cancellationToken = default)
        {
			var writerEntity = _mapper.Map<Writer>(request.CreateWriterDto);
            var createdWriter = await _writerRepository.AddAsync(writerEntity);

            return _mapper.Map<WriterDto>(createdWriter);
        }
    }
}
