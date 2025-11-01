using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface IAuthRepository
    {
        string CreateToken(User user, int channelId);
        string HashPassword(string password);
        bool VerifyPassword(string providedPassword, string storedHash);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
