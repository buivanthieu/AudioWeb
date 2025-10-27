using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Channels
{
    public class ChannelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }
        //public User User { get; set; } = null!;
        public IEnumerable<TrackDto> UploadedTrackDtos { get; set; } = new List<TrackDto>();
    }
}
