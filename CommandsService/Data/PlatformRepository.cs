namespace CommandsService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommandsService.Models;

    public class PlatformRepository : IPlatformRepository
    {
        #region Fields

        private readonly AppDbContext _context;

        #endregion

        #region Constructors

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return [.. _context.Platforms];
        }

        public bool PlatformExist(int platformId)
        {
            return _context.Platforms.Any(platform => platform.Id == platformId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        #endregion
    }
}
