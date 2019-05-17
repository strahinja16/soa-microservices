using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class WifiCapabilityService : IDataService
    {
        private IWifiCapabilityRepository wifiCapabilityRepository;

        private string[] capabilities;

        private void InitCapabilities()
        {
            capabilities = new string[2];
            capabilities[0] = "WPA";
            capabilities[1] = "WPA2";
        }

        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(2013, 1, 1);
            Random gen = new Random();
            return start.AddDays(gen.Next(730));
        }

        private string GetRandomCapability()
        {
            Random gen = new Random();
            return capabilities[gen.Next(2)];
        }

        public WifiCapabilityService(IWifiCapabilityRepository wifiCapabilityRepository)
        {
            this.wifiCapabilityRepository = wifiCapabilityRepository;
            this.InitCapabilities();
        }

        public void DoWork(IEnumerable<JObject> data)
        {
            DateTime date = GetRandomDate();
            string capability = GetRandomCapability();
            int count = 0;

            foreach (JObject obj in data)
            {
                string objCapabilities = (string)obj.Property("capabilities").Value;
                string objDate = (string)obj.Property("time").Value;

                //TO DO: date should be greater than random date

                if (objCapabilities.Contains(capability))
                {
                    ++count;
                }

            }

            WifiCapability wifiCapability = new WifiCapability
            {
                Capability = capability,
                Count = count,
                Time = date.ToString("dd-MM-yyyy HH:mm")
            };

            this.wifiCapabilityRepository.InsertWifiCapability(wifiCapability);
        }
    }
}