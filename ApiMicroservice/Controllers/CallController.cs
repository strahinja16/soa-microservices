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
    public class CallController : ControllerBase
    {
        private readonly ICallRepository _callRepository;
        public CallController(ICallRepository callRepository)
        {
            _callRepository = callRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var calls = _callRepository.GetCalls();
            return new OkObjectResult(calls);
        }
        [HttpGet("{id}", Name = "GetCall")]
        public IActionResult Get(int id)
        {
            var call = _callRepository.GetCallById(id);
            return new OkObjectResult(call);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Call call)
        {
            using (var scope = new TransactionScope())
            {
                _callRepository.InsertCall(call);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = call.Id }, call);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Call call)
        {
            if (call != null)
            {
                using (var scope = new TransactionScope())
                {
                    _callRepository.UpdateCall(call);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _callRepository.DeleteCall(id);
            return new OkResult();
        }
    }
}

