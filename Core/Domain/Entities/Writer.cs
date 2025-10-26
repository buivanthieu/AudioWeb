namespace AudioWeb.Core.Domain.Entities
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<OriginalStory> OriginalStories { get; set; } = new List<OriginalStory>();
    }
}
