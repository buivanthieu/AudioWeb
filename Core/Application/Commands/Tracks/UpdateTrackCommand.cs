using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;

namespace AudioWeb.Core.Application.Commands.Tracks
{
    public record UpdateTrackCommand(int TrackId, UpdateTrackDto UpdateTrackDto) : IRequest<TrackDto>
    {
    }
}
