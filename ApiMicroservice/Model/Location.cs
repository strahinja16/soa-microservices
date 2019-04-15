using System;
namespace ApiMicroservice.Model
{
    public class Location
    {
        public Guid Id { get; set; }
        public float Latitude { get; set; }
        public float Longtitude { get; set; }
        public float Altitude { get; set; }
        public string Time { get; set; }
        public float Accuracy { get; set; }
        public string Provider { get; set; }
        public float Speed { get; set; }
    }
}
