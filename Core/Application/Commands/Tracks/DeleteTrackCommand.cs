using MediatR;

namespace AudioWeb.Core.Application.Commands.Tracks
{
    public record DeleteTrackCommand(int TrackId) : IRequest<bool>
    {
    }
}
