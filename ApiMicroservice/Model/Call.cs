using System;
namespace ApiMicroservice.Model
{
    public class Call
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public float Duration { get; set; }
        public string Time { get; set; }
        public int Type { get; set; }
    }
}
