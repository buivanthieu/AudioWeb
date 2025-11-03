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
            return await _context.Tracks
                .Include(t => t.OriginalStory)
                    .ThenInclude(os => os.Writer)
                .Include(t => t.Channel)
                .Include(t => t.Category)
                .Include(t => t.TrackTags)
                    .ThenInclude(tt => tt.Tag)
                .ToListAsync();
        }

        public async Task<Track> GetByIdAsync(int id)
        {
            var track = await _context.Tracks
                .Include(t => t.OriginalStory)
                    .ThenInclude(os => os.Writer)
                .Include(t => t.Channel)
                .Include(t => t.Category)
                .Include(t => t.TrackTags)
                    .ThenInclude(tt => tt.Tag)
                .FirstOrDefaultAsync(t => t.Id == id);
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
                .Include(t => t.OriginalStory)
                    .ThenInclude(os => os.Writer)
                .Include(t => t.Channel.Name)
                .Include(t => t.Category.Name)
                .Include(t => t.TrackTags)
                    .ThenInclude(tt => tt.Tag.Name)
                .Where(t => t.ChannelId == channelId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Track>> SearchTracksAsync(string searchTerm)
        {
            return await _context.Tracks
                .Include(t => t.OriginalStory)
                    .ThenInclude(os => os.Writer)
                .Include(t => t.Channel)
                .Include(t => t.Category)
                .Include(t => t.TrackTags)
                    .ThenInclude(tt => tt.Tag)
                .Where(t => t.Title.Contains(searchTerm) ||
                            (t.Description != null && t.Description.Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Track>> SearchTracksDetailAsync(string? searchTerm, int? categoryId,
                IEnumerable<int>? tagIds, string? sortBy, string? sortOrder)
        {
            var query = _context.Tracks
                .Include(t => t.OriginalStory)
                    .ThenInclude(os => os.Writer)
                .Include(t => t.Channel)
                .Include(t => t.Category)
                .Include(t => t.TrackTags)
                    .ThenInclude(tt => tt.Tag)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchLower = searchTerm.Trim().ToLower();
                query = query.Where(t =>
                    t.Title.ToLower().Contains(searchLower) ||
                    (t.Description != null && t.Description.ToLower().Contains(searchLower)) ||
                    t.Channel.Name.ToLower().Contains(searchLower) ||
                    t.Category.Name.ToLower().Contains(searchLower) ||
                    (t.OriginalStory != null && t.OriginalStory.StoryName.ToLower().Contains(searchLower)) ||
                    (t.OriginalStory != null && t.OriginalStory.Writer != null && t.OriginalStory.Writer.Name.ToLower().Contains(searchLower)) ||
                    t.TrackTags.Any(tt => tt.Tag.Name.ToLower().Contains(searchLower))
                );
            }

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(t => t.CategoryId == categoryId.Value);
            }

            if (tagIds != null && tagIds.Any())
            {

                foreach (var tagId in tagIds)
                {
                    query = query.Where(t => t.TrackTags.Any(tt => tt.Tag.Id == tagId));
                }
            }

            bool isAsc = sortOrder?.ToLower() != "desc";

            query = sortBy?.ToLower() switch
            {
                "title" => isAsc ? query.OrderBy(t => t.Title) : query.OrderByDescending(t => t.Title),
                "uploadedat" => isAsc ? query.OrderBy(t => t.UploadedAt) : query.OrderByDescending(t => t.UploadedAt),
                _ => query.OrderByDescending(t => t.UploadedAt)
            };

            return await query.ToListAsync();
        }
    }
}
