using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using StatisticMicroservice.DbContext;
using MongoDB.Driver;
using MongoDB.Bson;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Model;

namespace StatisticMicroservice.Repository
{
    public class WifiCapabilityRepository : IWifiCapabilityRepository
    {
        private readonly AppDbContext _context = null;

        public WifiCapabilityRepository(IOptions<MongoSettings> settings)
        {
            _context = new AppDbContext(settings);
        }

    
        public async Task<IEnumerable<WifiCapability>> GetWifiCapabilities()
        {
            try
            {
                return await _context.WifiCapabilities
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<WifiCapability> GetWifiCapabilityById(string id)
        {
            try
            {
                return await _context.WifiCapabilities
                        .Find(doc => doc.Id == ObjectId.Parse(id))
                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task InsertWifiCapability(WifiCapability wifiCapability)
        {
            try
            {
                await _context.WifiCapabilities.InsertOneAsync(wifiCapability);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveWifiCapability(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.WifiCapabilities.DeleteOneAsync(
                        Builders<WifiCapability>.Filter.Eq("_id", ObjectId.Parse(id)));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateWifiCapability(WifiCapability wifiCapability)
        {
            var filter = Builders<WifiCapability>.Filter.Eq("_id", wifiCapability.Id);
            ReplaceOneResult result = await _context.WifiCapabilities
                                                    .ReplaceOneAsync(item => item.Id == wifiCapability.Id,
                                                                        wifiCapability,
                                                                        new UpdateOptions { IsUpsert = true });
        


            return result.IsAcknowledged;
        }
    }
}
