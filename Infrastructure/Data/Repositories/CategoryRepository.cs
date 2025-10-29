using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AudioDbContext _context;
        public CategoryRepository(AudioDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Tracks)
                    .ThenInclude(t => t.OriginalStory)
                        .ThenInclude(os => os.Writer)
                .Include(c => c.Tracks)
                    .ThenInclude(t => t.Channel)
                .Include(c => c.Tracks)
                    .ThenInclude(t => t.TrackTags)
                        .ThenInclude(tt => tt.Tag)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
