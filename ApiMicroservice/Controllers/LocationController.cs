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
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var locations = _locationRepository.GetLocations();
            return new OkObjectResult(locations);
        }
        [HttpGet("{id}", Name = "GetLocation")]
        public IActionResult Get(int id)
        {
            var location = _locationRepository.GetLocationById(id);
            return new OkObjectResult(location);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Location location)
        {
            using (var scope = new TransactionScope())
            {
                _locationRepository.InsertLocation(location);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = location.Id }, location);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Location location)
        {
            if (location != null)
            {
                using (var scope = new TransactionScope())
                {
                    _locationRepository.UpdateLocation(location);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _locationRepository.DeleteLocation(id);
            return new OkResult();
        }
    }
}

