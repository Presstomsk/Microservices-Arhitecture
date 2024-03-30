namespace CommandsService.Dtos
{
    public class CommandCreateDto
    {
        #region Properties

        public required string CommandLine { get; set; }

        public required int PlatformId { get; set; }

        #endregion
    }
}
