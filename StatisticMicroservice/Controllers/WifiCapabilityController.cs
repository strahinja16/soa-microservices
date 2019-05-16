using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository;
using StatisticMicroservice.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StatisticMicroservice.Controllers
{
    [Route("api/[controller]")]
    public class WifiCapabilityController : Controller
    {
        private readonly IWifiCapabilityRepository wifiCapabilityRepository;
        public WifiCapabilityController(IWifiCapabilityRepository wifiCapabilityRepository)
        {
            this.wifiCapabilityRepository = wifiCapabilityRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var wifiCapabilities = wifiCapabilityRepository.GetWifiCapabilities();
            return new OkObjectResult(wifiCapabilities);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WifiCapability wifiCapability)
        {
            return new OkResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return new OkResult();
        }
    }
}
