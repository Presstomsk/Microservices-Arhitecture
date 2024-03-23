namespace PlatformService.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Platform
    {
        #region Properties

        [Key, Required]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Publisher { get; set; }

        public required string Cost { get; set; }

        #endregion
    }
}
