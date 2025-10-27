using AudioWeb.Core.Application.DTOs.Tags;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Tags
{
    public record GetTagByIdQuery(int TagId) : IRequest<TagDto>
    {
    }
}
