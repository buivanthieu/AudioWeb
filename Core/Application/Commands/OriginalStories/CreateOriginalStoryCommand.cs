using AudioWeb.Core.Application.DTOs.OriginalStories;
using MediatR;

namespace AudioWeb.Core.Application.Commands.OriginalStories
{
    public record CreateOriginalStoryCommand(CreateOriginalStoryDto CreateOriginalStoryDto) : IRequest<OriginalStoryDto>
    {
    }
}
