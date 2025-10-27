using MediatR;

using AudioWeb.Core.Application.Commands.Tags;

namespace AudioWeb.Core.Application.Handlers.Tags
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, bool>
    {
        public DeleteTagHandler()
        {
        }

        public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
