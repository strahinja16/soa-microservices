using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface IBluetoothRepository
    {
        IEnumerable<Bluetooth> GetBluetooths();
        Bluetooth GetBluetoothById(int BluetoothId);
        void InsertBluetooth(Bluetooth bluetooth);
        void DeleteBluetooth(int BluetoothId);
        void UpdateBluetooth(Bluetooth bluetooth);
        void Save();
    }
}
