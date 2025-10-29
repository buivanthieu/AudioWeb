namespace AudioWeb.Core.Application.DTOs.Tracks
{
    public class TrackListDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AudioUrl { get; set; }

        public DateTime UploadedAt { get; set; }
        public string? Status { get; set; }

        public string? CategoryName { get; set; }
        public string? ChannelName { get; set; }
        public string? OriginalStoryName { get; set; }
        public IEnumerable<string> TagNames { get; set; } = new List<string>();
    }
}
