namespace PlatformService.Data
{
    using System.Collections.Generic;
    using PlatformService.Models;

    public interface IPlatformRepository
    {
        #region Methods

        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();

        Platform? GetPlatformById(int id);

        void CreatePlatform(Platform? platform);

        #endregion
    }
}
