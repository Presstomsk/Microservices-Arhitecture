namespace CommandsService.Data
{
    using CommandsService.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        #region Properties

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Command> Commands { get; set; }

        #endregion

        #region Constructors

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(c => c.Platform)
                .HasForeignKey(c => c.PlatformId);
            modelBuilder
                .Entity<Command>()
                .HasOne(c => c.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(c => c.PlatformId);
        }

        #endregion
    }
}
