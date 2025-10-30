using AudioWeb.Core.Application.DTOs.Tracks;

namespace AudioWeb.Core.Application.DTOs.OriginalStories
{
    public class OriginalStoryDto : OriginalStoryListDto
    {
        public int? WriterId { get; set; }
        public IEnumerable<TrackListDto> TrackListDtos { get; set; } = new List<TrackListDto>();

    }
}
