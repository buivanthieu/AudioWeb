using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Tracks
{
    public record SearchTracksQuery(string SearchTerm) : IRequest<IEnumerable<TrackListDto>>
    {
    }
}
