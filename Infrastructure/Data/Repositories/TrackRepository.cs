using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AudioDbContext _context;

        public TrackRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<Track> AddAsync(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return track;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Track with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            return await _context.Tracks.ToListAsync();
        }

        public async Task<Track> GetByIdAsync(int id)
        {
            var track = await _context.Tracks.FirstOrDefaultAsync(t => t.Id == id);
            if (track == null)
            {
                throw new KeyNotFoundException($"Track with ID {id} not found.");
            }
            return track;
        }

        public async Task<Track> UpdateAsync(Track track)
        {
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
            return track;
        }


        public async Task<IEnumerable<Track>> GetAllTracksByChannelIdAsync(int channelId)
        {
            return await _context.Tracks
                .Include(t => t.TrackTags)
                .Include(t => t.Category)
                .Where(t => t.ChannelId == channelId)
                .ToListAsync();
        }
    }
}
