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
    public class AddressCountService : IDataService
    {
        private IAddressCountRepository addressCountRepository;
        private Random gen = new Random(DateTime.Now.Ticks.GetHashCode());
        private string[] addresses;
        private MqttService mqttService;

        public AddressCountService(IAddressCountRepository addressCountRepository, MqttService mqttService)
        {
            this.addressCountRepository = addressCountRepository;
            this.mqttService = mqttService;
            this.InitAddresses();
        }

        private void InitAddresses() 
        {
            addresses = new string[3];
            addresses[0] = "+981";
            addresses[1] = "+983";
            addresses[2] = "+989";
        }

        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(2013, 1, 1);
            return start.AddDays(gen.Next(600));
        }

        private string GetRandomAddress()
        {
            return addresses[gen.Next(3)];
        }

        public void DoWork(IEnumerable<JObject> data)
        {
            DateTime date = GetRandomDate();
            string address = GetRandomAddress();
            int count = 0;

            foreach (JObject obj in data)
            {
                string objAddress = (string)obj.Property("address").Value;
                string objDateString = (string)obj.Property("date").Value;
                DateTime objDateTime = DateTime.Parse(objDateString);
                
                if (objAddress.Contains(address) && objDateTime.CompareTo(date) > 0)
                {
                    ++count;
                }

            }

            AddressCount addressCount = new AddressCount
            {
                Count = count,
                Address = address,
                Date = date.ToString("dd-MM-yyyy HH:mm")
            };

            this.addressCountRepository.InsertAddressCount(addressCount);
            mqttService.PublishMessage("address", JsonConvert.SerializeObject(addressCount));
        }
    }
}

