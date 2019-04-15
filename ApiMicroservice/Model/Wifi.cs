using System;
namespace ApiMicroservice.Model
{
    public class Wifi
    {
        public Guid Id { get; set; }
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public string Capabilities { get; set; }
        public float Level { get; set; }
        public float Frequency { get; set; }
        public string Time { get; set; }
    }
}