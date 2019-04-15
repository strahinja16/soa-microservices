using System;
namespace ApiMicroservice.Model
{
    public class SMS
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
    }
}
