namespace CommandService.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [ApiController, Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        #region Constructors

        public PlatformsController() { }

        #endregion

        #region Methods

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test from Platforms Controller");
        }

        #endregion
    }
}
