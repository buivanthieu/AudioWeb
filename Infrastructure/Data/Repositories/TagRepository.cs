using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AudioDbContext _context;

        public TagRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Tag with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (tag == null)
            {
                throw new KeyNotFoundException($"Tag with ID {id} not found.");
            }
            return tag;
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
