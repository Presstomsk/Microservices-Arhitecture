namespace CommandsService.Profiles
{
    using AutoMapper;
    using CommandsService.Dtos;
    using CommandsService.Models;

    public class PlatformProfile : Profile
    {
        #region Constructors

        public PlatformProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
        }

        #endregion
    }
}
