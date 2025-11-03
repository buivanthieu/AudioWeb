using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Application.DTOs.Channels;
using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Application.DTOs.Tags;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Enums;

namespace AudioWeb.Core.Application.DTOs.Tracks
{
    public class TrackDto : TrackListDto
    {
        //public int Id { get; set; }

        //public string? Title { get; set; }
        //public string? Description { get; set; }
        //public string? AudioUrl { get; set; } 
        //public DateTime UploadedAt { get; set; }
        //public string? Status { get; set; }
        //public int ChannelId { get; set; }
        //public int CategoryId { get; set; }
        //public int OriginalStoryId { get; set; }
        //public IEnumerable<TrackTag> TrackTags { get; set; } = new List<TrackTag>();
        //public IEnumerable<PlaylistItem> PlaylistItems { get; set; } = new List<PlaylistItem>();
        public CategoryListDto CategoryListDto { get; set; } = new CategoryListDto();
        public ChannelListDto ChannelListDto { get; set; } = new ChannelListDto();
        public OriginalStoryListDto OriginalStoryListDto { get; set; } = new OriginalStoryListDto();
        public IEnumerable<TagListDto> TagListDtos { get; set; } = new List<TagListDto>();
    }
}
