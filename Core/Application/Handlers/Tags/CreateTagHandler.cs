using MediatR;

using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Application.Commands.Tags;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, TagDto>

    {
        public CreateTagHandler()
        {
        }

        public async Task<TagDto> Handle(CreateTagCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
