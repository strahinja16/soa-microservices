using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using ApiMicroservice.Model;
using ApiMicroservice.Repository;
using ApiMicroservice.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WifiController : ControllerBase
    {
        private readonly IWifiRepository _wifiRepository;
        public WifiController(IWifiRepository wifiRepository)
        {
            _wifiRepository = wifiRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var wifis = _wifiRepository.GetWifis();
            return new OkObjectResult(wifis);
        }
        [HttpGet("{id}", Name = "GetWifi")]
        public IActionResult Get(Guid id)
        {
            var wifi = _wifiRepository.GetWifiById(id);
            return new OkObjectResult(wifi);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Wifi wifi)
        {
            using (var scope = new TransactionScope())
            {
                _wifiRepository.InsertWifi(wifi);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = wifi.Id }, wifi);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Wifi wifi)
        {
            if (wifi != null)
            {
                using (var scope = new TransactionScope())
                {
                    _wifiRepository.UpdateWifi(wifi);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _wifiRepository.DeleteWifi(id);
            return new OkResult();
        }
    }
}


