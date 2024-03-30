namespace CommandsService.Data
{
    using System.Collections.Generic;
    using CommandsService.Models;

    public interface ICommandRepository
    {
        #region Methods

        bool SaveChanges();

        IEnumerable<Command> GetCommandsForPlatform(int platformId);

        Command? GetCommand(int platformId, int commandId);

        void CreateCommand(int platformId, Command command);

        #endregion
    }
}
