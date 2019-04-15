using System;
namespace ApiMicroservice.Model
{
    public class Application
    {
        public Guid Id { get; set; }
        public string ProcessName { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}
