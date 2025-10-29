using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Application.Queries.OriginalStories;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.OriginalStories
{
    public class GetAllOriginalStoriesHandler : IRequestHandler<GetAllOriginalStoriesQuery, IEnumerable<OriginalStoryDto>>
    {
        private readonly IOriginalStoryRepository _originalStoryRepository;
        private readonly IMapper _mapper;
        public GetAllOriginalStoriesHandler(IOriginalStoryRepository originalStoryRepository, IMapper mapper)
        {
            _originalStoryRepository = originalStoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OriginalStoryDto>> Handle(GetAllOriginalStoriesQuery request, CancellationToken cancellationToken)
        {
            var originalStories = await _originalStoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OriginalStoryDto>>(originalStories);
        }
    }
}
