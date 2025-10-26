using AudioWeb.Core.Domain.Enums;

namespace AudioWeb.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = UserRole.Member.ToString();

        public Channel Channel { get; set; } = null!;
    }
}
