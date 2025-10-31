using AudioWeb.Core.Domain.Enums;

namespace AudioWeb.Core.Domain.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ItemCount { get; set; } = 0; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Channel Channel { get; set; } = null!;
        public IEnumerable<PlaylistItem> PlaylistItems { get; set; } = new List<PlaylistItem>();
    }
}
