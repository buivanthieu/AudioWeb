using MediatR;
using AudioWeb.Core.Application.Queries.Writers;
using AudioWeb.Core.Application.DTOs.Writers;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class GetAllWritersHandler : IRequestHandler<GetAllWritersQuery, IEnumerable<WriterDto>>
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;
        public GetAllWritersHandler(IWriterRepository writerRepository, IMapper mapper)
        {
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WriterDto>> Handle(GetAllWritersQuery request, CancellationToken cancellationToken = default)
        {
			var writers = await _writerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WriterDto>>(writers);
        }
    }
}
