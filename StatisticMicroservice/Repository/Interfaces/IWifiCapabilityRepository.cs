using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticMicroservice.Model;

namespace StatisticMicroservice.Repository.Interfaces
{
    public interface IWifiCapabilityRepository
    {
        Task<IEnumerable<WifiCapability>> GetWifiCapabilities();

        Task InsertWifiCapability(WifiCapability wifiCapability);
        
        Task<bool> RemoveWifiCapability(string id);
        
    }
}
