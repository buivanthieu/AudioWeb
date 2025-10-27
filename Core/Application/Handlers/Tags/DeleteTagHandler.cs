using MediatR;

using AudioWeb.Core.Application.Commands.Tags;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, bool>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public DeleteTagHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken = default)
        {
			var tag = await _tagRepository.GetByIdAsync(request.TagId);
            if (tag == null)
            {
                throw new Exception("Tag not found.");
            }
            var result = await _tagRepository.DeleteAsync(request.TagId);
            return result;
        }
    }
}
