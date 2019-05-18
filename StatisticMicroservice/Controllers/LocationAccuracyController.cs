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
    public class LocationAccuracyController : Controller
    {
        private readonly ILocationAccuracyRepository locationAccuracyRepository;
        public LocationAccuracyController(ILocationAccuracyRepository locationAccuracyRepository)
        {
            this.locationAccuracyRepository = locationAccuracyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var locationAccuracies = locationAccuracyRepository.GetLocationAccuracies();
            return new OkObjectResult(locationAccuracies.Result);
        }

        [HttpGet("{id}", Name = "GetLocationAccuracy")]
        public async Task<IActionResult> Get(string id)
        {
            var locationAccuracy = await locationAccuracyRepository.GetLocationAccuracyById(id);
            return new OkObjectResult(locationAccuracy);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocationAccuracy locationAccuracy)
        {
            using (var scope = new TransactionScope())
            {
                locationAccuracyRepository.InsertLocationAccuracy(locationAccuracy);
                scope.Complete();
                return CreatedAtAction(nameof(Get), locationAccuracy);
            }
        }

        [HttpPut]
        public async Task<IActionResult>Put([FromBody] LocationAccuracy locationAccuracy)
        {
            if (locationAccuracy != null)
            {
                using (var scope = new TransactionScope())
                {
                    bool success = await locationAccuracyRepository.UpdateLocationAccuracy(locationAccuracy);
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
            bool success = await locationAccuracyRepository.RemoveLocationAccuracy(id);
            if (success)
            {
                return new OkResult();
            }
            return BadRequest();
        }
    }
}
