namespace PlatformService.Data
{
    using Microsoft.EntityFrameworkCore;
    using PlatformService.Models;

    public class AppDbContext : DbContext
    {
        #region Properties

        public DbSet<Platform> Platforms { get; set; }

        #endregion

        #region Constructors

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        #endregion
    }
}
