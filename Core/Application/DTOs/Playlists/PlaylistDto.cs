using AudioWeb.Core.Application.DTOs.Tracks;


namespace AudioWeb.Core.Application.DTOs.Playlists
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string? Title { get; set; } 
        public string? Description { get; set; }
        public int ItemCount { get; set; }
        public DateTime CreatedAt { get; set; } 
        public IEnumerable<TrackListDto> TrackListDtos { get; set; } = new List<TrackListDto>();
    }
}
