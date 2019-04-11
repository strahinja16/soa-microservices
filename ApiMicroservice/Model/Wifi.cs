using System;
namespace ApiMicroservice.Model
{
    public class Wifi
    {
        public int Id { get; set; }
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public string Capabilities { get; set; }
        public float Level { get; set; }
        public float Frequency { get; set; }
        public DateTime Time { get; set; }
    }
}