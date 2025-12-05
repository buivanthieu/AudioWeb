using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class PlaylistItemRepository : IPlaylistItemRepository
    {
        private readonly AudioDbContext _context;

        public PlaylistItemRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<PlaylistItem> AddAsync(PlaylistItem item)
        {
            _context.PlaylistItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.PlaylistItems.FindAsync(id);
            if (item != null)
            {
                _context.PlaylistItems.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"PlaylistItem with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<PlaylistItem>> GetAllAsync()
        {
            return await _context.PlaylistItems.ToListAsync();
        }

        public async Task<PlaylistItem> GetByIdAsync(int id)
        {
            var item = await _context.PlaylistItems.FirstOrDefaultAsync(p => p.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException($"PlaylistItem with ID {id} not found.");
            }
            return item;
        }

        public async Task<IEnumerable<PlaylistItem>> GetByPlaylistIdAsync(int playlistId)
        {
            return await _context.PlaylistItems
                .Where(p => p.PlaylistId == playlistId)
                .OrderBy(p => p.OrderIndex)
                .ToListAsync();
        }

        public async Task<PlaylistItem?> GetByPlaylistAndTrackAsync(int playlistId, int trackId)
        {
            return await _context.PlaylistItems
                .FirstOrDefaultAsync(p => p.PlaylistId == playlistId && p.TrackId == trackId);
        }

        public async Task<PlaylistItem> UpdateAsync(PlaylistItem item)
        {
            _context.PlaylistItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<int> GetMaxOrderIndexAsync(int playlistId)
        {
            var maxOrderIndex = await _context.PlaylistItems
                .Where(p => p.PlaylistId == playlistId)
                .MaxAsync(p => (int?)p.OrderIndex)
                ?? 0;
            return maxOrderIndex;
        }
    }
}
