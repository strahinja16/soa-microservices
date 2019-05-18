using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatisticMicroservice.Model
{
    public class WifiCapability
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Capability { get; set; } = string.Empty;

        public int Count { get; set; } = 0;

        public string Time;
    }
}
