using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;

namespace AudioWeb.Core.Application.Commands.Tracks
{
    public record CreateTrackCommand(CreateTrackDto CreateTrackDto) : IRequest<TrackDto>
    {
    }
}
