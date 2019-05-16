using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class LocationAccuracyService : ILocationAccuracyService
    {
        private ILocationAccuracyRepository locationAccuracyRepository;

        public LocationAccuracyService(ILocationAccuracyRepository locationAccuracyRepository)
        {
            this.locationAccuracyRepository = locationAccuracyRepository;
        }

        public void findLocationCountByAccuracy(double accuracy, string time)
        {
            // 1. get locations with http client
            // 2. find all the location records after <time> and filter those with accuracy >= <accuracy> e.g. 0.6
            // 3. count the filtered locations
            // 4. insert LocationAccuracy to Mongo -> { <accuracy>, count(3), <time> }
        }
    }
}

