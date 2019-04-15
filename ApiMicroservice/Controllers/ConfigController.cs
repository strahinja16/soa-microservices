using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMicroservice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly BackgroundService backgroundService;
        public ConfigController(BackgroundService backgroundService)
        {
            this.backgroundService = backgroundService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var timeout = backgroundService.GetDataDelay;
            return new OkObjectResult(timeout);
        }
    }
}