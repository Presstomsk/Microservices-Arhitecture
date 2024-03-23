namespace PlatformService.Dtos
{
    public class PlatformCreateDto
    {
        #region Properties

        public required string Name { get; set; }

        public required string Publisher { get; set; }

        public required string Cost { get; set; }

        #endregion
    }
}
