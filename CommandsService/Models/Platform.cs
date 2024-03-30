namespace CommandsService.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Platform
    {
        #region Properties

        [Key]
        public required int Id { get; set; }

        public required int ExternalId { get; set; }

        public required string Name { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();

        #endregion
    }
}
