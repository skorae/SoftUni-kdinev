using Microsoft.EntityFrameworkCore;
using MishMash.Entities;

namespace MishMash.Data
{
    public class MishMashDbContext : DbContext
    {
        public MishMashDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<UserChannel> UserChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>()
                 .HasKey(x => x.Id);

            model.Entity<Channel>()
                .HasKey(x => x.Id);

            model.Entity<Channel>()
                .HasMany(x => x.Tags);

            model.Entity<Tag>()
                .HasKey(x => x.Id);

            model.Entity<UserChannel>()
                .HasKey(x => new { x.FollowerId, x.ChannelId });

            model.Entity<UserChannel>()
                .HasOne(x => x.Channel)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.ChannelId);

            model.Entity<UserChannel>()
                .HasOne(x => x.Follower)
                .WithMany(x => x.Channels)
                .HasForeignKey(x => x.FollowerId);
        }
    }
}
