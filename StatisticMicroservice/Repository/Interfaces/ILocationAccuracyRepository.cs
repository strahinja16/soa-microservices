using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticMicroservice.Model;

namespace StatisticMicroservice.Repository.Interfaces
{
    public interface ILocationAccuracyRepository
    {
        Task<IEnumerable<LocationAccuracy>> GetLocationAccuracies();

        Task InsertLocationAccuracy(LocationAccuracy locationAccuracy);

        Task<bool> UpdateLocationAccuracy(LocationAccuracy locationAccuracy);

        Task<bool> RemoveLocationAccuracy(string id);

    }
}