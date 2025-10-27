using MediatR;

namespace AudioWeb.Core.Application.Commands.Writers
{
    public record DeleteWriterCommand (int WriterId) : IRequest<bool>
    {
    }
}
