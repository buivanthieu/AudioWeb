namespace AudioWeb.Core.Domain.Entities
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public string? AvatarUrl { get; set; }
        public string? CoverArtUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public IEnumerable<Track> UploadedTracks { get; set; } = new List<Track>();
        public IEnumerable<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
