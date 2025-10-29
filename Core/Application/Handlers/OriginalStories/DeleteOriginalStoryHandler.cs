using AudioWeb.Core.Application.Commands.OriginalStories;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.OriginalStories
{
    public class DeleteOriginalStoryHandler :  IRequestHandler<DeleteOriginalStoryCommand, bool>
    {
        private readonly IOriginalStoryRepository _originalStoryRepository;
        private readonly IMapper _mapper;
        public DeleteOriginalStoryHandler(IOriginalStoryRepository originalStoryRepository, IMapper mapper)
        {
            _originalStoryRepository = originalStoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteOriginalStoryCommand request, CancellationToken cancellationToken)
        {
            var originalStory = await _originalStoryRepository.GetByIdAsync(request.OriginalStoryId);
            if (originalStory == null)
            {
                throw new Exception("story not found.");
            }
            var result = await _originalStoryRepository.DeleteAsync(request.OriginalStoryId);
            return result;
        }
    }
}
