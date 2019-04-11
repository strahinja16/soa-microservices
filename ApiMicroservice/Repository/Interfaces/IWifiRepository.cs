using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface IWifiRepository
    {
        IEnumerable<Wifi> GetWifis();
        Wifi GetWifiById(int WifiId);
        void InsertWifi(Wifi wifi);
        void DeleteWifi(int WifiId);
        void UpdateWifi(Wifi wifi);
        void Save();
    }
}