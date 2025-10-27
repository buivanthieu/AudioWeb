using MediatR;
using AudioWeb.Core.Application.Queries.Writers;
using AudioWeb.Core.Application.DTOs.Writers;

namespace AudioWeb.Core.Application.Handlers.Writers
{
    public class GetAllWritersHandler : IRequestHandler<GetAllWritersQuery, IEnumerable<WriterDto>>
    {
        public GetAllWritersHandler()
        {
        }

        public async Task<IEnumerable<WriterDto>> Handle(GetAllWritersQuery request, CancellationToken cancellationToken = default)
        {
			throw new NotImplementedException();
        }
    }
}
