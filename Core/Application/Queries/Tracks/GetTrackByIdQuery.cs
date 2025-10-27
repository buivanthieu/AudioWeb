using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Tracks
{
    public record GetTrackByIdQuery(int TrackId) : IRequest<TrackDto>
    {
    }
}
