using System;
namespace ApiMicroservice.Model
{
    public class Application
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
