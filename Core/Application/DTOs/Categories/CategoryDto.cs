using AudioWeb.Core.Application.DTOs.Tracks;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IEnumerable<TrackDto> TrackDtos { get; set; } = new List<TrackDto>();
    }
}
