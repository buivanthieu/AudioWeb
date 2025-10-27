using MediatR;

namespace AudioWeb.Core.Application.Commands.Tags
{
    public record DeleteTagCommand (int TagId) : IRequest<bool>
    {
    }
}
