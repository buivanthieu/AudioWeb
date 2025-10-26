namespace AudioWeb.Core.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<TrackTag> TrackTags { get; set; } = new List<TrackTag>();

}
}
