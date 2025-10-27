using AudioWeb.Core.Application.DTOs.Tags;
using MediatR;

namespace AudioWeb.Core.Application.Commands.Tags
{
    public record CreateTagCommand (CreateTagDto CreateTagDto): IRequest<TagDto>
    {
    }
}
