using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataMicroservice.Services
{
    public class StorageService: IStorageService
    {
        private List<object> list;
        private List<Timer> timers;
        public int Ttl { get; } = 30000;
        public int GetItemsNumber { get; } = 10;
        public StorageService()
        {
            list = new List<object>();
            timers = new List<Timer>();
        }

        public void addItem(object item)
        {
            list.Add(item);
            timers.Add(new Timer(RemoveElement, null, Ttl, Timeout.Infinite));
        }

        public IEnumerable<object> getItems()
        {
            return list.Take<object>(GetItemsNumber);
        }

        private void RemoveElement(object item)
        {
            try
            {
                list.RemoveRange(0, 1);
                timers.RemoveRange(0, 1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
