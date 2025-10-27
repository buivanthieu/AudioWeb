namespace AudioWeb.Core.Application.DTOs.Channels
{
    public class CreateChannelDto
    {
        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
