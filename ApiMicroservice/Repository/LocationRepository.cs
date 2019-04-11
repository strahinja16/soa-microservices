using Microsoft.EntityFrameworkCore;
using ApiMicroservice.DbContexts;
using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMicroservice.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _dbContext;

        public LocationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteLocation(int LocationId)
        {
            var product = _dbContext.Locations.Find(LocationId);
            _dbContext.Locations.Remove(product);
            Save();
        }

        public Location GetLocationById(int LocationId)
        {
            return _dbContext.Locations.Find(LocationId);
        }

        public IEnumerable<Location> GetLocations()
        {
            return _dbContext.Locations.ToList();
        }

        public void InsertLocation(Location location)
        {
            _dbContext.Add(location);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _dbContext.Entry(location).State = EntityState.Modified;
            Save();
        }
    }
}
