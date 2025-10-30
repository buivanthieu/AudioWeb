using AudioWeb.Core.Application.DTOs.Tags;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Tags
{
    public class GetAllTagsQuery() : IRequest<IEnumerable<TagListDto>>
    {
    }
}
