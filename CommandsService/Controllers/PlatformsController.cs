namespace CommandsService.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CommandsService.Data;
    using CommandsService.Dtos;
    using CommandsService.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController, Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        #region Fields

        private readonly IPlatformRepository _plaformRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _plaformRepository = platformRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            IEnumerable<Platform> platforms = _plaformRepository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test from Platforms Controller");
        }

        #endregion
    }
}
