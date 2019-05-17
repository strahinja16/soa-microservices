using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticMicroservice.Services.Interfaces
{
    public interface IDataService
    {
        void DoWork(IEnumerable<JObject> data);
    }
}
