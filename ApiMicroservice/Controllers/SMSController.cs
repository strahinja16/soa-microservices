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
    public class SMSController : ControllerBase
    {
        private readonly ISMSRepository _smsRepository;
        public SMSController(ISMSRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var smss = _smsRepository.GetSMSes();
            return new OkObjectResult(smss);
        }
        [HttpGet("{id}", Name = "GetSms")]
        public IActionResult Get(int id)
        {
            var sms = _smsRepository.GetSMSById(id);
            return new OkObjectResult(sms);
        }
        [HttpPost]
        public IActionResult Post([FromBody] SMS sms)
        {
            using (var scope = new TransactionScope())
            {
                _smsRepository.InsertSMS(sms);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = sms.Id }, sms);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] SMS sms)
        {
            if (sms != null)
            {
                using (var scope = new TransactionScope())
                {
                    _smsRepository.UpdateSMS(sms);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _smsRepository.DeleteSMS(id);
            return new OkResult();
        }
    }
}


