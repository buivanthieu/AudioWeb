using AudioWeb.Core.Application.DTOs.Tracks;
using MediatR;


namespace AudioWeb.Core.Application.Queries.Tracks
{
    public record SearchTracksDetailQuery(
        string? SearchTerm,
        int? CategoryId,
        IEnumerable<int>? TagIds,

        string? SortBy,
        string? SortOrder

        ) : IRequest<IEnumerable<TrackListDto>>
    {
    }
}
