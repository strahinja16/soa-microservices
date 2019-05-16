using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using StatisticMicroservice.Model;
using StatisticMicroservice.DbContext;
using MongoDB.Driver;
using MongoDB.Bson;
using StatisticMicroservice.Repository.Interfaces;

namespace StatisticMicroservice.Repository
{
    public class LocationAccuracyRepository : ILocationAccuracyRepository
    {
        private readonly AppDbContext _context = null;

        public LocationAccuracyRepository(IOptions<MongoSettings> settings)
        {
            _context = new AppDbContext(settings);
        }

        public async Task<IEnumerable<LocationAccuracy>> GetLocationAccuracies()
        {
            try
            {
                return await _context.LocationAccuracies
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task InsertLocationAccuracy(LocationAccuracy locationAccuracy)
        {
            try
            {
                await _context.LocationAccuracies.InsertOneAsync(locationAccuracy);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveLocationAccuracy(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.LocationAccuracies.DeleteOneAsync(
                        Builders<LocationAccuracy>.Filter.Eq("_id", ObjectId.Parse(id)));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateLocationAccuracy(LocationAccuracy locationAccuracy)
        {
            var filter = Builders<LocationAccuracy>.Filter.Eq("_id", locationAccuracy.Id);
            ReplaceOneResult result = await _context.LocationAccuracies.ReplaceOneAsync(filter, locationAccuracy);

            return result.IsAcknowledged;
        }
    }
}
