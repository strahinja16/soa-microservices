using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatisticMicroservice.Model
{
    public class AddressCount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public int Count { get; set; } = 0;

        public string Date;
    }
}
