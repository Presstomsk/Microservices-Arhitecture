namespace CommandsService.Profiles
{
    using AutoMapper;
    using CommandsService.Dtos;
    using CommandsService.Models;

    public class CommandProfile : Profile
    {
        #region Constructors

        public CommandProfile()
        {
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
        }

        #endregion
    }
}
