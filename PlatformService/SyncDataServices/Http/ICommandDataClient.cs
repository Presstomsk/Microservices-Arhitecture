namespace PlatformService.SyncDataServices.Http
{
    using System.Threading.Tasks;
    using PlatformService.Dtos;

    public interface ICommandDataClient
    {
        #region Methods

        Task SendPlatformToCommand(PlatformReadDto platform);

        #endregion
    }
}
