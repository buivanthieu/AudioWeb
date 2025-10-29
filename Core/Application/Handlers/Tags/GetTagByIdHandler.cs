using MediatR;

using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.Queries.Tags;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, TagDto>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public GetTagByIdHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
			var tag = await _tagRepository.GetByIdAsync(request.TagId);
            if (tag == null)
            {
                throw new Exception("Tag not found.");
            }
            return _mapper.Map<TagDto>(tag);
        }
    }
}
