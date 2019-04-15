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
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var applications = _applicationRepository.GetApplications();
            return new OkObjectResult(applications);
        }
        [HttpGet("{id}", Name = "GetApplication")]
        public IActionResult Get(Guid id)
        {
            var application = _applicationRepository.GetApplicationById(id);
            return new OkObjectResult(application);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Application application)
        {
            using (var scope = new TransactionScope())
            {
                _applicationRepository.InsertApplication(application);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = application.Id }, application);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Application application)
        {
            if (application != null)
            {
                using (var scope = new TransactionScope())
                {
                    _applicationRepository.UpdateApplication(application);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _applicationRepository.DeleteApplication(id);
            return new OkResult();
        }
    }
}
