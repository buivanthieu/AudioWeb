using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface IPlaylistItemRepository
    {
        Task<IEnumerable<PlaylistItem>> GetAllAsync();
        Task<IEnumerable<PlaylistItem>> GetByPlaylistIdAsync(int playlistId);
        Task<PlaylistItem?> GetByPlaylistAndTrackAsync(int playlistId, int trackId);
        Task<PlaylistItem> GetByIdAsync(int id);
        Task<PlaylistItem> AddAsync(PlaylistItem item);
        Task<PlaylistItem> UpdateAsync(PlaylistItem item);
        Task<bool> DeleteAsync(int id);
    }
}
