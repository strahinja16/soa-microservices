using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class WifiCapabilityService : IDataService
    {
        private IWifiCapabilityRepository wifiCapabilityRepository;
        private Random gen = new Random(DateTime.Now.Ticks.GetHashCode());
        private string[] capabilities;
        private MqttService mqttService;

        public WifiCapabilityService(IWifiCapabilityRepository wifiCapabilityRepository, MqttService mqttService)
        {
            this.wifiCapabilityRepository = wifiCapabilityRepository;
            this.mqttService = mqttService;
            this.InitCapabilities();
        }

        private void InitCapabilities()
        {
            capabilities = new string[2];
            capabilities[0] = "WPA";
            capabilities[1] = "WPA2";
        }

        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(2013, 1, 1);
            return start.AddDays(gen.Next(600));
        }

        private string GetRandomCapability()
        {
            return capabilities[gen.Next(2)];
        }

        public void DoWork(IEnumerable<JObject> data)
        {
            DateTime date = GetRandomDate();
            string capability = GetRandomCapability();
            int count = 0;

            foreach (JObject obj in data)
            {
                string objCapabilities = (string)obj.Property("capabilities").Value;
                string objDateString = (string)obj.Property("time").Value;
                objDateString = objDateString.Substring(0, objDateString.Length - 22);
                DateTime objDateTime = DateTime.Parse(objDateString);

                if (objCapabilities.Contains(capability) && objDateTime.CompareTo(date) > 0)
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
            Console.WriteLine(JsonConvert.SerializeObject(wifiCapability));
            mqttService.PublishMessage("wifi", JsonConvert.SerializeObject(wifiCapability));
        }
    }
}