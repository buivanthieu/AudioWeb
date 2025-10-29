using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioWeb.Core.Application.Commands.Writers;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class DeleteWriterHandler : IRequestHandler<DeleteWriterCommand, bool>
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;
        public DeleteWriterHandler(IWriterRepository writerRepository, IMapper mapper)
        {
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteWriterCommand request, CancellationToken cancellationToken)
        {
			var writer = await _writerRepository.GetByIdAsync(request.WriterId);
            if (writer == null)
            {
                throw new Exception("Writer not found.");
            }
            await _writerRepository.DeleteAsync(writer.Id);
            return true;
        }
    }
}
