using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface IWifiRepository
    {
        IEnumerable<Wifi> GetWifis();
        Wifi GetWifiById(Guid WifiId);
        void InsertWifi(Wifi wifi);
        void DeleteWifi(Guid WifiId);
        void UpdateWifi(Wifi wifi);
        void Save();
    }
}