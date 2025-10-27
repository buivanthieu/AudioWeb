using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Tracks
{
    public record GetAllTracksUploadByUserIdQuery(int UserId) : IRequest<IEnumerable<TrackDto>>
    {
    }
}
