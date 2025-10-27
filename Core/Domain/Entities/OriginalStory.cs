namespace AudioWeb.Core.Domain.Entities
{
    public class OriginalStory
    {
        public int Id { get; set; }
        public string StoryName { get; set; } = string.Empty;


        public int WriterId { get; set; }
        public Writer Writer { get; set; } = null!;
        public IEnumerable<Track> Tracks { get; set; } = new List<Track>();
    }
}
