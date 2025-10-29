using AudioWeb.Core.Application.DTOs.OriginalStories;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.DTOs.Writers
{
    public class WriterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public IEnumerable<OriginalStoryDto> OriginalStorieDtos { get; set; } = new List<OriginalStoryDto>();
    }
}
