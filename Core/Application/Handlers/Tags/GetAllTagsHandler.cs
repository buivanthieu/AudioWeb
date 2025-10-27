using System.Threading;
using MediatR;

using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.Queries.Tags;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public GetAllTagsHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken = default)
        {
			var tags = await _tagRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }
    }
}
