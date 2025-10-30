using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Categories
{
    public class CategoryDto : CategoryListDto
    {
        public IEnumerable<TrackListDto> TrackListDtos { get; set; } = new List<TrackListDto>();
    }
}
