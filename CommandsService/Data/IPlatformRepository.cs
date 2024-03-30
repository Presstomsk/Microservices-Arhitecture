namespace CommandsService.Data
{
    using System.Collections.Generic;
    using CommandsService.Models;

    public interface IPlatformRepository
    {
        #region Methods

        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();

        void CreatePlatform(Platform platform);

        bool PlatformExist(int platformId);

        #endregion
    }
}
