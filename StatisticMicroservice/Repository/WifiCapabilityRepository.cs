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
                        Builders<WifiCapability>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
