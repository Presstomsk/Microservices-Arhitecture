namespace CommandsService.Dtos
{
    public class CommandReadDto
    {
        #region Properties

        public int Id { get; set; }

        public string? HowTo { get; set; }

        public string? CommandLine { get; set; }

        public int PlatformId { get; set; }

        #endregion
    }
}
