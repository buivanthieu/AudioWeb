using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.OriginalStories
{
    public class OriginalStoryDto
    {
        public int Id { get; set; }
        public string StoryName { get; set; } = string.Empty;
        public int WriterId { get; set; }
        public IEnumerable<TrackDto> TrackDtos { get; set; } = new List<TrackDto>();

    }
}
