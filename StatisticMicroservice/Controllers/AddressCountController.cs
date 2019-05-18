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
    public class AddressCountController : Controller
    {
        private readonly IAddressCountRepository addressCountRepository;
        public AddressCountController(IAddressCountRepository addressCountRepository)
        {
            this.addressCountRepository = addressCountRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var addressCounts = addressCountRepository.GetAddressCounts();
            return new OkObjectResult(addressCounts.Result);
        }

        [HttpGet("{id}", Name = "GetAddressCount")]
        public async Task<IActionResult> Get(string id)
        {
            var addrCount = await addressCountRepository.GetAddressCountById(id);
            return new OkObjectResult(addrCount);
        }


        [HttpPost]
        public IActionResult Post([FromBody] AddressCount addressCount)
        {
            using (var scope = new TransactionScope())
            {
                addressCountRepository.InsertAddressCount(addressCount);
                scope.Complete();
                return CreatedAtAction(nameof(Get), addressCount);
            };

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddressCount addressCount)
        {
            if (addressCount != null)
            {
                using (var scope = new TransactionScope())
                {
                    bool success = await addressCountRepository.UpdateAddressCount(addressCount);
                    scope.Complete();
                    if (success)
                    {
                        return new OkResult();
                    }
                    return BadRequest();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool success = await addressCountRepository.RemoveAddressCount(id);
            if (success) 
            {
                return new OkResult();
            }

            return BadRequest();
        }
    }
}
