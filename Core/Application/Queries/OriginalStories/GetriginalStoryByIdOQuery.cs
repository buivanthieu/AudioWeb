using AudioWeb.Core.Application.DTOs.OriginalStories;
using MediatR;

namespace AudioWeb.Core.Application.Queries.OriginalStories
{
    public record GetriginalStoryByIdOQuery(int OriginalStoryId) : IRequest<OriginalStoryDto>
    {
    }
}
