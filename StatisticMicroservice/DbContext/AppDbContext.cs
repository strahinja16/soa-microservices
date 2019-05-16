using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StatisticMicroservice.Model;

namespace StatisticMicroservice.DbContext
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _database = null;

        public AppDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<WifiCapability> WifiCapabilities
        {
            get
            {
                return _database.GetCollection<WifiCapability>("WifiCapability");
            }
        }
    }
}

