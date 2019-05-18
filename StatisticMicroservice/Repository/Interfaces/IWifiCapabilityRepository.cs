using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticMicroservice.Model;

namespace StatisticMicroservice.Repository.Interfaces
{
    public interface IWifiCapabilityRepository
    {
        Task<IEnumerable<WifiCapability>> GetWifiCapabilities();

        Task<WifiCapability> GetWifiCapabilityById(string id);

        Task InsertWifiCapability(WifiCapability wifiCapability);

        Task<bool> UpdateWifiCapability(WifiCapability wifiCapability);

        Task<bool> RemoveWifiCapability(string id);
        
    }
}
