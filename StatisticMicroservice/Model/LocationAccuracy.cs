using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatisticMicroservice.Model
{
    public class LocationAccuracy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public double Accuracy { get; set; } = 0.0f;

        public int Count { get; set; } = 0;

        public string Time;
    }
}
