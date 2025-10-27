using AudioWeb.Core.Application.DTOs.Writers;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Writers
{
    public record GetWriterByIdQuery(int WriterId) : IRequest<WriterDto>
    {
    }
}
