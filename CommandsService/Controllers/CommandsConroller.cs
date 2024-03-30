namespace CommandsService.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using CommandsService.Data;
    using CommandsService.Dtos;
    using CommandsService.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController, Route("api/c/platforms/{platformId}/[controller]")]
    public class CommandsController : ControllerBase
    {
        #region Fields

        private readonly ICommandRepository _commandRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public CommandsController(
            ICommandRepository commandRepository,
            IPlatformRepository platformRepository,
            IMapper mapper
        )
        {
            _commandRepository = commandRepository;
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            if (!_platformRepository.PlatformExist(platformId))
            {
                return NotFound();
            }

            IEnumerable<Command> commands = _commandRepository.GetCommandsForPlatform(platformId);

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
        {
            if (!_platformRepository.PlatformExist(platformId))
            {
                return NotFound();
            }

            Command? command = _commandRepository.GetCommand(platformId, commandId);

            return command != null ? Ok(_mapper.Map<CommandReadDto>(command)) : NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(
            int platformId,
            CommandCreateDto commandDto
        )
        {
            if (!_platformRepository.PlatformExist(platformId))
            {
                return NotFound();
            }

            Command command = _mapper.Map<Command>(commandDto);
            _commandRepository.CreateCommand(platformId, command);
            _commandRepository.SaveChanges();
            CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(
                nameof(GetCommandForPlatform),
                new { platformId, commandId = commandReadDto.Id },
                commandReadDto
            );
        }

        #endregion
    }
}
