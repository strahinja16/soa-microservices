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
        private Random gen = new Random(DateTime.Now.Ticks.GetHashCode());

        public LocationAccuracyService(ILocationAccuracyRepository locationAccuracyRepository)
        {
            this.locationAccuracyRepository = locationAccuracyRepository;
        }

        private DateTime GetRandomDate()
        {
            DateTime start = new DateTime(2013, 1, 1);
            return start.AddDays(gen.Next(600));
        }

        private double GetRandomAccuracy()
        {
            return gen.Next(100);
        }

        public void DoWork(IEnumerable<JObject> data)
        {
            DateTime date = GetRandomDate();
            double accuracy = GetRandomAccuracy();
            int count = 0;

            foreach (JObject obj in data)
            {
                double objAccuracy = (double)obj.Property("accuracy").Value;
                string objDateString = (string)obj.Property("time").Value;
                DateTime objDateTime = DateTime.Parse(objDateString);

                if (objAccuracy >= accuracy && objDateTime.CompareTo(date) > 0)
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

            this.locationAccuracyRepository.InsertLocationAccuracy(locationAccuracy);
        }
    }
}

