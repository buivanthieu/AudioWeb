using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Tags
{
    public class TagDto : TagListDto
    {
        

        //public IEnumerable<TrackTag> TrackTags { get; set; } = new List<TrackTag>();
        public IEnumerable<TrackListDto> TrackListDtos { get; set; } = new List<TrackListDto>();
    }
}
