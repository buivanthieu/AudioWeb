using AudioWeb.Core.Application.Commands.OriginalStories;
using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.OriginalStories
{
    public class CreateOriginalStoryHandler : IRequestHandler<CreateOriginalStoryCommand, OriginalStoryDto>
    {
        private readonly IOriginalStoryRepository _originalStoryRepository;
        private readonly IMapper _mapper;
        public CreateOriginalStoryHandler(IOriginalStoryRepository originalStoryRepository, IMapper mapper)
        {
            _originalStoryRepository = originalStoryRepository;
            _mapper = mapper;
        }
        public async Task<OriginalStoryDto> Handle(CreateOriginalStoryCommand request, CancellationToken cancellationToken = default)
        {
            var originalStory = _mapper.Map<OriginalStory>(request.CreateOriginalStoryDto);
            var createdOriginalStory = await _originalStoryRepository.AddAsync(originalStory);
            return _mapper.Map<OriginalStoryDto>(createdOriginalStory);
        }
    }
}
