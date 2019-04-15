using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMicroservice.Services.DataService
{
    public class CallDataService: IDataService
    {
        private ICallRepository callRepository;

        public CallDataService(ICallRepository callRepository)
        {
            this.callRepository = callRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            Call c = data.ToObject<Call>();

            Call call = callRepository.GetCallById(c.Id);

            if (call == null)
            {
                callRepository.InsertCall(c);
            }
        }
    }
}
