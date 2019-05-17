using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class LocationAccuracyService : IDataService
    {
        private ILocationAccuracyRepository locationAccuracyRepository;

        public LocationAccuracyService(ILocationAccuracyRepository locationAccuracyRepository)
        {
            this.locationAccuracyRepository = locationAccuracyRepository;
        }

        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(2013, 1, 1);
            Random gen = new Random();
            return start.AddDays(gen.Next(730));
        }

        private double GetRandomAccuracy()
        {
            Random gen = new Random();
            return gen.Next(10) / 10;
        }

        public void DoWork(IEnumerable<JObject> data)
        {
            DateTime date = GetRandomDate();
            double accuracy = GetRandomAccuracy();
            int count = 0;

            foreach (JObject obj in data)
            {
                double objAccuracy = (double)obj.Property("accuracy").Value;
                string objDate = (string)obj.Property("time").Value;

                //TO DO: date should be greater than random date

                if (objAccuracy >= accuracy)
                {
                    ++count;
                }

            }

            LocationAccuracy locationAccuracy = new LocationAccuracy
            {
                Count = count,
                Accuracy = accuracy,
                Time = date.ToString("dd-MM-yyyy HH:mm")
            };

            Console.WriteLine(locationAccuracy);
            this.locationAccuracyRepository.InsertLocationAccuracy(locationAccuracy);
        }
    }
}

