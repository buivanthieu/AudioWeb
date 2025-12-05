using AudioWeb.Core.Application.DTOs.Tags;

namespace AudioWeb.Core.Application.DTOs.Tracks
{
    public class CreateTrackDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AudioUrl { get; set; }
        public DateTime UploadedAt { get; set; }
        public string? Status { get; set; }
        public int ChannelId { get; set; }
        public int CategoryId { get; set; }

        public string? CoverArtUrl { get; set; }

        public string? WriterName { get; set; }
        public string? OriginalStoryName { get; set; }

        public IEnumerable<string> TagNames { get; set; } = new List<string>();
    }
}
