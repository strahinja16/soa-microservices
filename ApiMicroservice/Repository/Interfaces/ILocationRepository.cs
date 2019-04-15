using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        Location GetLocationById(Guid LocationId);
        void InsertLocation(Location location);
        void DeleteLocation(Guid LocationId);
        void UpdateLocation(Location location);
        void Save();
    }
}