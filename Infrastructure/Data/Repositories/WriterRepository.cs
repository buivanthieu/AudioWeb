using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AudioWeb.Infrastructure.Data.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly AudioDbContext _context;

        public WriterRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<Writer> AddAsync(Writer writer)
        {
            _context.Writers.Add(writer);
            await _context.SaveChangesAsync();
            return writer;
        }

        public async Task DeleteAsync(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            if (writer != null)
            {
                _context.Writers.Remove(writer);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Writer with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Writer>> GetAllAsync()
        {
            return await _context.Writers.ToListAsync();
        }

        public async Task<Writer> GetByIdAsync(int id)
        {
            var writer = await _context.Writers.FirstOrDefaultAsync(w => w.Id == id);
            if (writer == null)
            {
                throw new KeyNotFoundException($"Writer with ID {id} not found.");
            }
            return writer;
        }

        public async Task<Writer> UpdateAsync(Writer writer)
        {
            _context.Writers.Update(writer);
            await _context.SaveChangesAsync();
            return writer;
        }
    }
}
