using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;

namespace AudioWeb.Core.Application.Queries.Tracks
{
    public record GetAllTracksUploadByChannelIdQuery(int ChannelId) : IRequest<IEnumerable<TrackDto>>
    {
    }
}
