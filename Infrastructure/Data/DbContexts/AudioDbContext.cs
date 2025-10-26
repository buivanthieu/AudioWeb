using AudioWeb.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AudioWeb.Infrastructure.Data.DbContexts
{
    public class AudioDbContext : DbContext
    {
        public AudioDbContext(DbContextOptions<AudioDbContext> options)
            : base(options)
        {
        }

        // DbSets 
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<OriginalStory> OriginalStories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TrackTag> TrackTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Channel>()
                .HasOne(c => c.User)
                .WithOne(u => u.Channel)
                .HasForeignKey<Channel>(c => c.UserId)
                .IsRequired();

            modelBuilder.Entity<OriginalStory>()
                .HasOne(os => os.Writer)
                .WithMany(w => w.OriginalStories)
                .HasForeignKey(os => os.WriterId)
                .IsRequired();
            
            modelBuilder.Entity<Track>()
                .HasOne(t => t.OriginalStory)
                .WithMany(os => os.Tracks)
                .HasForeignKey(t => t.OriginalStoryId)
                .IsRequired();
            modelBuilder.Entity<Track>()
                .HasOne(t => t.Channel)
                .WithMany(c => c.UploadedTracks)
                .HasForeignKey(t => t.ChannelId)
                .IsRequired();
            modelBuilder.Entity<Track>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tracks)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired();

            modelBuilder.Entity<TrackTag>()
                .HasOne(tt => tt.Track)
                .WithMany(t => t.TrackTags)
                .HasForeignKey(tt => tt.TrackId)
                .IsRequired();
            modelBuilder.Entity<TrackTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TrackTags)
                .HasForeignKey(tt => tt.TagId)
                .IsRequired();

            modelBuilder.Entity<PlaylistItem>()
                .HasOne(pi => pi.Playlist)
                .WithMany(p => p.PlaylistItems)
                .HasForeignKey(pi => pi.PlaylistId)
                .IsRequired();

            modelBuilder.Entity<PlaylistItem>()
                .HasOne(pi => pi.Track)
                .WithMany(t => t.PlaylistItems)
                .HasForeignKey(pi => pi.TrackId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlaylistItem>()
               .HasIndex(pi => new { pi.PlaylistId, pi.TrackId })
               .IsUnique();
        }
    }
}
