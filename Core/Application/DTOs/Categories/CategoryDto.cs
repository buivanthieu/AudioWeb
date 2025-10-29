using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Categories
{
    public class CategoryDto : CategoryListDto
    {
        public IEnumerable<TrackListDto> TrackDtos { get; set; } = new List<TrackListDto>();
    }
}
