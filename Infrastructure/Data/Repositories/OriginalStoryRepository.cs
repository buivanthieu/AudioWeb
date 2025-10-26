using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class OriginalStoryRepository : IOriginalStoryRepository
    {
        private readonly AudioDbContext _context;

        public OriginalStoryRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<OriginalStory> AddAsync(OriginalStory story)
        {
            _context.OriginalStories.Add(story);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task DeleteAsync(int id)
        {
            var story = await _context.OriginalStories.FindAsync(id);
            if (story != null)
            {
                _context.OriginalStories.Remove(story);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"OriginalStory with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<OriginalStory>> GetAllAsync()
        {
            return await _context.OriginalStories.ToListAsync();
        }

        public async Task<OriginalStory> GetByIdAsync(int id)
        {
            var story = await _context.OriginalStories.FirstOrDefaultAsync(s => s.Id == id);
            if (story == null)
            {
                throw new KeyNotFoundException($"OriginalStory with ID {id} not found.");
            }
            return story;
        }

        public async Task<OriginalStory> UpdateAsync(OriginalStory story)
        {
            _context.OriginalStories.Update(story);
            await _context.SaveChangesAsync();
            return story;
        }
    }
}
