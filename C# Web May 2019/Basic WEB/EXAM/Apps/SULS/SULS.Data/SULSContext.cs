namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SULS.Models;

    public class SULSContext : DbContext
    {
        public SULSContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>()
                .HasKey(x => x.Id);

            model.Entity<Problem>()
                .HasKey(x => x.Id);

            model.Entity<Submission>()
                .HasKey(x => x.Id);

            base.OnModelCreating(model);
        }
    }
}