using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly AudioDbContext _context;

        public ChannelRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<Channel> AddAsync(Channel channel)
        {
            _context.Channels.Add(channel);
            await _context.SaveChangesAsync();
            return channel;
        }

        public async Task DeleteAsync(int id)
        {
            var channel = await _context.Channels.FindAsync(id);
            if (channel != null)
            {
                _context.Channels.Remove(channel);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Channel with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Channel>> GetAllAsync()
        {
            return await _context.Channels.ToListAsync();
        }

        public async Task<Channel> GetByIdAsync(int id)
        {
            var channel = await _context.Channels.FirstOrDefaultAsync(c => c.Id == id);
            if (channel == null)
            {
                throw new KeyNotFoundException($"Channel with ID {id} not found.");
            }
            return channel;
        }

        public async Task<Channel> UpdateAsync(Channel channel)
        {
            _context.Channels.Update(channel);
            await _context.SaveChangesAsync();
            return channel;
        }
    }
}
