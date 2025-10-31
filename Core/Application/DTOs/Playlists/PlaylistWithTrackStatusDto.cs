namespace AudioWeb.Core.Application.DTOs.Playlists
{
    public class PlaylistWithTrackStatusDto
    {

        public int PlaylistId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool ContainsTrack { get; set; }
    }
}
