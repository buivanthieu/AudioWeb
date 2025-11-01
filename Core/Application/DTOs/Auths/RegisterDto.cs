namespace AudioWeb.Core.Application.DTOs.Auths
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ChannelName { get; set; } = string.Empty;
    }
}
