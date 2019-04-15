using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMicroservice.Services.DataService
{
    public class BluetoothDataService: IDataService
    {
        private IBluetoothRepository bluetoothRepository;

        public BluetoothDataService(IBluetoothRepository bluetoothRepository)
        {
            this.bluetoothRepository = bluetoothRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            Bluetooth bt = data.ToObject<Bluetooth>();

            Bluetooth bluetooth = bluetoothRepository.GetBluetoothById(bt.Id);

            if (bluetooth == null)
            {
                bluetoothRepository.InsertBluetooth(bt);
            }
        }
    }
}
