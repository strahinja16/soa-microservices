using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMicroservice.Services.DataService
{
    public class LocationDataService: IDataService
    {
        private ILocationRepository locationRepository;

        public LocationDataService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            Location l = data.ToObject<Location>();

            Location location = locationRepository.GetLocationById(l.Id);

            if (location == null)
            {
                locationRepository.InsertLocation(l);
            }
        }
    }
}
