using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface IBluetoothRepository
    {
        IEnumerable<Bluetooth> GetBluetooths();
        Bluetooth GetBluetoothById(Guid BluetoothId);
        void InsertBluetooth(Bluetooth bluetooth);
        void DeleteBluetooth(Guid BluetoothId);
        void UpdateBluetooth(Bluetooth bluetooth);
        void Save();
    }
}
