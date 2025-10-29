using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Application.Queries.OriginalStories;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.OriginalStories
{
    public class GetOriginalStoryByIdHandler : IRequestHandler<GetOriginalStoryByIdQuery, OriginalStoryDto>
    {
        private readonly IOriginalStoryRepository _originalStoryRepository;
        private readonly IMapper _mapper;
        public GetOriginalStoryByIdHandler(IOriginalStoryRepository originalStoryRepository, IMapper mapper)
        {
            _originalStoryRepository = originalStoryRepository;
            _mapper = mapper;
        }
        public async Task<OriginalStoryDto> Handle(GetOriginalStoryByIdQuery request, CancellationToken cancellationToken)
        {
            var originalStory = await _originalStoryRepository.GetByIdAsync(request.OriginalStoryId);
            if (originalStory == null)
            {
                throw new Exception("story not found.");
            }
            return _mapper.Map<OriginalStoryDto>(originalStory);
        }
    }
}
