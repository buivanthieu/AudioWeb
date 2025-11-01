using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface ITrackRepository
    {
        Task<Track> GetByIdAsync(int id);
        Task<IEnumerable<Track>> GetAllAsync();

        Task<Track> AddAsync(Track track);
        Task<Track> UpdateAsync(Track track);
        Task<bool> DeleteAsync(int id);


        Task<IEnumerable<Track>> GetAllTracksByChannelIdAsync(int channelId);

        Task<IEnumerable<Track>> SearchTracksAsync(string searchTerm);

        Task<IEnumerable<Track>> SearchTracksDetailAsync
            (
                string? searchTerm, 
                int? categoryId, 
                IEnumerable<int>? tagIds, 
                string? sortBy, 
                string? sortOrder
            );

    }
}
