using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMicroservice.Services.DataService
{
    public class SMSDataService: IDataService
    {
        private ISMSRepository smsRepository;

        public SMSDataService(ISMSRepository smsRepository)
        {
            this.smsRepository = smsRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            SMS s = data.ToObject<SMS>();

            SMS sms = smsRepository.GetSMSById(s.Id);

            if (sms == null)
            {
                smsRepository.InsertSMS(s);
            }
        }
    }
}
