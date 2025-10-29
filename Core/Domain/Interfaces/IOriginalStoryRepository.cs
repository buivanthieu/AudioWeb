using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface IOriginalStoryRepository
    {
        Task<OriginalStory> GetByIdAsync(int id);
        Task<IEnumerable<OriginalStory>> GetAllAsync();

        Task<OriginalStory> AddAsync(OriginalStory originalStory);
        Task<OriginalStory> UpdateAsync(OriginalStory originalStory);
        Task<bool> DeleteAsync(int id);

        Task<OriginalStory?> GetByNameAsync(string storyName);

    }
}
