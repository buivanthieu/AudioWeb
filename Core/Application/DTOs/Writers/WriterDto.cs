using AudioWeb.Core.Application.DTOs.OriginalStories;

namespace AudioWeb.Core.Application.DTOs.Writers
{
    public class WriterDto : WriterListDto
    {
          public IEnumerable<OriginalStoryListDto> OriginalStoryListDtos { get; set; } = new List<OriginalStoryListDto>();
    }
}
