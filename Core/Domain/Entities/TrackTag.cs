using System.ComponentModel.DataAnnotations;

namespace AudioWeb.Core.Domain.Entities
{
    public class TrackTag
    {
        [Key]
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int TagId { get; set; }
        public Track? Track { get; set; }
        public Tag? Tag { get; set; }

    }
}
