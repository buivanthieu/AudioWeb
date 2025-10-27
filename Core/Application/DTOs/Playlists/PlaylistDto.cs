using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Enums;

namespace AudioWeb.Core.Application.DTOs.Playlists
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string? Title { get; set; } 
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int ItemCount { get; set; }

        public DateTime CreatedAt { get; set; } 

        //public IEnumerable<PlaylistItem> PlaylistItems { get; set; } = new List<PlaylistItem>();
        public IEnumerable<TrackDto> TrackDtos { get; set; } = new List<TrackDto>();
    }
}
