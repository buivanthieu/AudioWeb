namespace AudioWeb.Core.Application.DTOs.OriginalStories
{
    public class CreateOriginalStoryDto
    {
        public string StoryName { get; set; } = string.Empty;

        public int WriterId { get; set; }
    }
}
