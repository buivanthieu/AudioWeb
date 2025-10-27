using AudioWeb.Core.Application.DTOs.Writers;
using MediatR;

namespace AudioWeb.Core.Application.Commands.Writers
{
    public record CreateWriterCommand(CreateWriterDto CreateWriterDto) : IRequest<WriterDto>
    {
    }
}
