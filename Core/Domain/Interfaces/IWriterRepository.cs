using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface IWriterRepository
    {
        Task<Writer> GetByIdAsync(int id);
        Task<IEnumerable<Writer>> GetAllAsync();

        Task<Writer> AddAsync(Writer writer);
        Task<Writer> UpdateAsync(Writer writer);
        Task<bool> DeleteAsync(int id);

    }
}
