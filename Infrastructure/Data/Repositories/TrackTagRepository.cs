using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class TrackTagRepository : ITrackTagRepository
    {
        private readonly AudioDbContext _context;

        public TrackTagRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<TrackTag> AddAsync(TrackTag trackTag)
        {
            _context.TrackTags.Add(trackTag);
            await _context.SaveChangesAsync();
            return trackTag;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var trackTag = await _context.TrackTags.FindAsync(id);
            if (trackTag != null)
            {
                _context.TrackTags.Remove(trackTag);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"TrackTag with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<TrackTag>> GetAllAsync()
        {
            return await _context.TrackTags.ToListAsync();
        }

        public async Task<TrackTag> GetByIdAsync(int id)
        {
            var trackTag = await _context.TrackTags.FirstOrDefaultAsync(tt => tt.Id == id);
            if (trackTag == null)
            {
                throw new KeyNotFoundException($"TrackTag with ID {id} not found.");
            }
            return trackTag;
        }

        public async Task<TrackTag> UpdateAsync(TrackTag trackTag)
        {
            _context.TrackTags.Update(trackTag);
            await _context.SaveChangesAsync();
            return trackTag;
        }
    }
}
