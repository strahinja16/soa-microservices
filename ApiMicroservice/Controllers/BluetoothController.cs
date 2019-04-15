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
    public class BluetoothController : ControllerBase
    {
        private readonly IBluetoothRepository _bluetoothRepository;
        public BluetoothController(IBluetoothRepository bluetoothRepository)
        {
            _bluetoothRepository = bluetoothRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bluetooths = _bluetoothRepository.GetBluetooths();
            return new OkObjectResult(bluetooths);
        }
        [HttpGet("{id}", Name = "GetBluetooth")]
        public IActionResult Get(Guid id)
        {
            var bluetooth = _bluetoothRepository.GetBluetoothById(id);
            return new OkObjectResult(bluetooth);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Bluetooth bluetooth)
        {
            using (var scope = new TransactionScope())
            {
                _bluetoothRepository.InsertBluetooth(bluetooth);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = bluetooth.Id }, bluetooth);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Bluetooth bluetooth)
        {
            if (bluetooth != null)
            {
                using (var scope = new TransactionScope())
                {
                    _bluetoothRepository.UpdateBluetooth(bluetooth);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _bluetoothRepository.DeleteBluetooth(id);
            return new OkResult();
        }
    }
}

