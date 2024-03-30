namespace CommandsService.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Command
    {
        #region Properties

        [Key]
        public required int Id { get; set; }

        public required string HowTo { get; set; }

        public required string CommandLine { get; set; }

        public required int PlatformId { get; set; }

        public Platform? Platform { get; set; }

        #endregion
    }
}
