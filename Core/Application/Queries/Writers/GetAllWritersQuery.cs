using AudioWeb.Core.Application.DTOs.Writers;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Writers
{
    public record GetAllWritersQuery() : IRequest<IEnumerable<WriterDto>>
    {
    }
}
