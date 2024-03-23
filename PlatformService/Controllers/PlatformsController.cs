namespace PlatformService.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PlatformService.Data;
    using PlatformService.Dtos;
    using PlatformService.Models;

    [ApiController, Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        #region Fields

        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public PlatformsController(IPlatformRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            IEnumerable<Platform> platforms = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Platform? platform = _repository.GetPlatformById(id);

            return platform != null ? Ok(_mapper.Map<PlatformReadDto>(platform)) : NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            Platform platform = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(platform);
            _repository.SaveChanges();
            PlatformReadDto platformReadDto = _mapper.Map<PlatformReadDto>(platform);

            return CreatedAtRoute(
                nameof(GetPlatformById),
                new { platformReadDto.Id },
                platformReadDto
            );
        }

        #endregion
    }
}
