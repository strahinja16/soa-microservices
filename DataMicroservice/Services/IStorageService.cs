using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMicroservice.Services
{
    public interface IStorageService
    {
        int Ttl { get; }
        int GetItemsNumber { get; }
        void addItem(object item);
        IEnumerable<object> getItems();
    }
}
