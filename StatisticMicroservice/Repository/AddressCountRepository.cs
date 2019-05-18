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
    public class AddressCountRepository : IAddressCountRepository
    {
        private readonly AppDbContext _context = null;

        public AddressCountRepository(IOptions<MongoSettings> settings)
        {
            _context = new AppDbContext(settings);
        }

        public async Task<AddressCount> GetAddressCountById(string id)
        {
            try
            {
                return await _context.AddressCounts
                        .Find(doc => doc.Id == ObjectId.Parse(id))
                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<AddressCount>> GetAddressCounts()
        {
            try
            {
                return await _context.AddressCounts
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task InsertAddressCount(AddressCount addressCount)
        {
            try
            {
                await _context.AddressCounts.InsertOneAsync(addressCount);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAddressCount(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.AddressCounts.DeleteOneAsync(
                        Builders<AddressCount>.Filter.Eq("_id", ObjectId.Parse(id)));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateAddressCount(AddressCount addressCount)
        {
            var filter = Builders<AddressCount>.Filter.Eq("_id", addressCount.Id);
            ReplaceOneResult result = await _context.AddressCounts.ReplaceOneAsync(filter, addressCount);

            Console.WriteLine(result);

            return result.IsAcknowledged;
        }
    }
}
