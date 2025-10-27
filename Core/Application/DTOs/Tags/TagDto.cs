using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Tags
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //public IEnumerable<TrackTag> TrackTags { get; set; } = new List<TrackTag>();
        public IEnumerable<TrackDto> TrackDtos { get; set; } = new List<TrackDto>();
    }
}
