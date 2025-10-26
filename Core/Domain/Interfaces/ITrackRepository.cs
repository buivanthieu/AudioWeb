using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface ITrackRepository
    {
        Task<Track> GetByIdAsync(int id);
        Task<IEnumerable<Track>> GetAllAsync();

        Task<Track> AddAsync(Track track);
        Task<Track> UpdateAsync(Track track);
        Task DeleteAsync(int id);

    }
}
