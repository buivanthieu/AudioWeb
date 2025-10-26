using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly AudioDbContext _context;

        public PlaylistRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<Playlist> AddAsync(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task DeleteAsync(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlists.Remove(playlist);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Playlist with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return await _context.Playlists.ToListAsync();
        }

        public async Task<Playlist> GetByIdAsync(int id)
        {
            var playlist = await _context.Playlists.FirstOrDefaultAsync(p => p.Id == id);
            if (playlist == null)
            {
                throw new KeyNotFoundException($"Playlist with ID {id} not found.");
            }
            return playlist;
        }

        public async Task<Playlist> UpdateAsync(Playlist playlist)
        {
            _context.Playlists.Update(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }
    }
}
