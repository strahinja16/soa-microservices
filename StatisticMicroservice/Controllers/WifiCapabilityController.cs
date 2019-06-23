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
            return new OkObjectResult(wifiCapabilities.Result);
        }

        [HttpGet("{id}", Name = "GetWifiCapability")]
        public async Task<IActionResult> Get(string id)
        {
            var wifiCapability = await wifiCapabilityRepository.GetWifiCapabilityById(id);
            return new OkObjectResult(wifiCapability);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WifiCapability wifiCapability)
        {
            using (var scope = new TransactionScope())
            {
                wifiCapabilityRepository.InsertWifiCapability(wifiCapability);
                scope.Complete();
                return CreatedAtAction(nameof(Get), wifiCapability);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] WifiCapability wifiCapability)
        {
            if (wifiCapability != null)
            {
                    bool success = await wifiCapabilityRepository.UpdateWifiCapability(wifiCapability);

                    if (success)
                    {
                        return new OkResult();
                    }
                    return BadRequest();
               
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool success = await wifiCapabilityRepository.RemoveWifiCapability(id);
            if (success) {
                return new OkResult();
            }
            return BadRequest();
        }
    }
}
