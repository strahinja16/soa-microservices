using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class WifiCapabilityService: IWifiCapabilityService
    {
        private IWifiCapabilityRepository wifiCapabilityRepository;

        public WifiCapabilityService(IWifiCapabilityRepository wifiCapabilityRepository)
        {
            this.wifiCapabilityRepository = wifiCapabilityRepository;
        }

        public void findWifiCountWithCapability(string capability, string time) 
        {
            // 1. get wifis with http client
            // 2. find all the wifis records after <time> and filter those with <capability> e.g. WPA2
            // 3. count the filtered wifis
            // 4. insert WIfiCapability to Mongo -> { <capability>, count(3), <time> }
        }
    }
}
