using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> GetByIdAsync(int id);
        Task<IEnumerable<Tag>> GetAllAsync();

        Task<Tag> AddAsync(Tag tag);
        Task<Tag> UpdateAsync(Tag tag);
        Task DeleteAsync(int id);

    }
}
