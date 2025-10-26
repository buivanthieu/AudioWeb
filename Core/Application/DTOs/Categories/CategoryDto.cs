using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<TrackDto> TrackDtos { get; set; } = new List<Track>();
    }
}
