using MediatR;

namespace AudioWeb.Core.Application.Commands.OriginalStories
{
    public record DeleteOriginalStoryCommand(int OriginalStoryId) : IRequest<bool>
    {
    }
}
