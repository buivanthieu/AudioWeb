using AudioWeb.Core.Application.DTOs.OriginalStories;
using MediatR;

namespace AudioWeb.Core.Application.Queries.OriginalStories
{
    public record GetOriginalStoryByIdQuery(int OriginalStoryId) : IRequest<OriginalStoryDto>
    {
    }
}
