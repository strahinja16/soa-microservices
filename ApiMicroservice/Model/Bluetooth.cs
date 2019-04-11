using System;
namespace ApiMicroservice.Model
{
    public class Bluetooth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string BondStatus { get; set; }
        public DateTime Time { get; set; }
    }
}
