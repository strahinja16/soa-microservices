using System;
namespace ApiMicroservice.Model
{
    public class Location
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longtitude { get; set; }
        public float Altitude { get; set; }
        public DateTime Time { get; set; }
        public float Accuracy { get; set; }
        public string Provider { get; set; }
        public float Speed { get; set; }
    }
}
