using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Tracks
{
    public record GetAllTracksQuery() : IRequest<IEnumerable<TrackDto>>
    {
    }
}
