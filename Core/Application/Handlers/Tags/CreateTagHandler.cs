using MediatR;

using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.Commands.Tags;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, TagDto>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public CreateTagHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<TagDto> Handle(CreateTagCommand request, CancellationToken cancellationToken = default)
        {
            var tag = _mapper.Map<Tag>(request.CreateTagDto);
            var createdTag = await _tagRepository.AddAsync(tag);
            return _mapper.Map<TagDto>(createdTag);
        }
    }
}
