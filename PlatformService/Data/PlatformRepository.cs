namespace PlatformService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlatformService.Models;

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

        public void CreatePlatform(Platform? platform)
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

        public Platform? GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(platform => platform.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        #endregion
    }
}
