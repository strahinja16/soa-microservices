using System;
namespace ApiMicroservice.Model
{
    public class Call
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public float Duration { get; set; }
        public DateTime Time { get; set; }
        public int Type { get; set; }
    }
}
