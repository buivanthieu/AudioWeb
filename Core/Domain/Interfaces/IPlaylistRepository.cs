using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<Playlist> GetByIdAsync(int id);
        Task<IEnumerable<Playlist>> GetAllAsync();

        Task<Playlist> AddAsync(Playlist playlist);
        Task<Playlist> UpdateAsync(Playlist playlist);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Playlist>> GetAllPlaylistsByChannelIdAsync(int channelId);

    }
}
