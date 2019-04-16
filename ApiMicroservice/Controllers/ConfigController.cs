using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMicroservice.Model.Dto;
using ApiMicroservice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly BackgroundTimer backgroundTimer;
        public ConfigController(BackgroundTimer backgroundTimer)
        {
            this.backgroundTimer = backgroundTimer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var timeout = backgroundTimer.GetDataDelay;
            return new OkObjectResult(timeout);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConfigDto config)
        {
            int tm = config.Timeout;
            backgroundTimer.GetDataDelay = tm;
            return new OkObjectResult(tm);
        }
    }
}