using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Enums;

namespace AudioWeb.Core.Application.DTOs.Tracks
{
    public class TrackDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AudioUrl { get; set; } 
        public DateTime UploadedAt { get; set; }
        public string? Status { get; set; }
        public int ChannelId { get; set; }
        public int CategoryId { get; set; }
        public int OriginalStoryId { get; set; }
        //public IEnumerable<TrackTag> TrackTags { get; set; } = new List<TrackTag>();
        //public IEnumerable<PlaylistItem> PlaylistItems { get; set; } = new List<PlaylistItem>();

        public IEnumerable<TagDto> TagDtos { get; set; } = new List<TagDto>();
    }
}
