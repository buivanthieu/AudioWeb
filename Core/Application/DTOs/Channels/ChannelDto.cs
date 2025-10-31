using AudioWeb.Core.Application.DTOs.Playlists;
using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Channels
{
    public class ChannelDto : ChannelListDto
    {
        
        public IEnumerable<TrackListDto> UploadedTrackListDtos { get; set; } = new List<TrackListDto>();
        public IEnumerable<PlaylistDto> PlaylistDtos { get; set; } = new List<PlaylistDto>();
    }
}
