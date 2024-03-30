namespace CommandsService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommandsService.Models;

    public class CommandRepository : ICommandRepository
    {
        #region Fields

        private readonly AppDbContext _context;

        #endregion

        #region Constructors

        public CommandRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformId;
            _context.Commands.Add(command);
        }

        public Command? GetCommand(int platformId, int commandId)
        {
            return _context
                .Commands.Where(command =>
                    command.PlatformId == platformId && command.Id == commandId
                )
                .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands.Where(command => command.PlatformId == platformId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        #endregion
    }
}
