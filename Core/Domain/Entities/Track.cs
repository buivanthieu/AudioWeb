using AudioWeb.Core.Domain.Enums;

namespace AudioWeb.Core.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string AudioUrl { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = TrackStatus.Public.ToString();


        public string? CoverArtUrl { get; set; }
        public int DurationInSeconds { get; set; } = 0;
        //public long ViewCount { get; set; } = 0;
        //public int LikeCount { get; set; } = 0;


        public Channel Channel { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int OriginalStoryId { get; set; }
        public OriginalStory OriginalStory { get; set; } = null!;
        public IEnumerable<TrackTag> TrackTags { get; set; } = new List<TrackTag>();
        public IEnumerable<PlaylistItem> PlaylistItems { get; set; } = new List<PlaylistItem>();
    }
}
