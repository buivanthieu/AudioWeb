using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface ITrackTagRepository
    {
        Task<TrackTag> GetByIdAsync(int id);
        Task<IEnumerable<TrackTag>> GetAllAsync();
        Task<TrackTag> AddAsync(TrackTag trackTag);
        Task<TrackTag> UpdateAsync(TrackTag trackTag);
        Task<bool> DeleteAsync(int id);
    }
}
