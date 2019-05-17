using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class AddressCountService : IDataService
    {
        private IAddressCountRepository addressCountRepository;
        private string[] addresses;

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
            Random gen = new Random();
            return start.AddDays(gen.Next(730));
        }

        private string GetRandomAddress()
        {
            Random gen = new Random();
            return addresses[gen.Next(3)];
        }


        public AddressCountService(IAddressCountRepository addressCountRepository)
        {
            this.addressCountRepository = addressCountRepository;
            this.InitAddresses();
        }

        public void DoWork(IEnumerable<JObject> data)
        {
            DateTime date = GetRandomDate();
            string address = GetRandomAddress();
            int count = 0;

            foreach (JObject obj in data)
            {
                string objAddress = (string)obj.Property("address").Value;
                string objDate = (string)obj.Property("date").Value;

                //TO DO: date should be greater than random date

                if (objAddress.Contains(address))
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
        }
    }
}

