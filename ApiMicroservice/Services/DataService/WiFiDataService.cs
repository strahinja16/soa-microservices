using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using Newtonsoft.Json.Linq;

namespace ApiMicroservice.Services.DataService
{
    public class WiFiDataService : IDataService
    {
        private IWifiRepository wifiRepository;

        public WiFiDataService(IWifiRepository wifiRepository)
        {
            this.wifiRepository = wifiRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            Wifi w = data.ToObject<Wifi>();

            Wifi wifi = wifiRepository.GetWifiById(w.Id);

            if (wifi == null)
            {
                wifiRepository.InsertWifi(w);
            }
        }
    }
}
