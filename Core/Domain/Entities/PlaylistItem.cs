using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AudioWeb.Core.Domain.Entities
{
    public class PlaylistItem
    {
        [Key]
        public int Id { get; set; } 

        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public int OrderIndex { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public Playlist Playlist { get; set; } = null!;
        public Track Track { get; set; } = null!;
    }
}
