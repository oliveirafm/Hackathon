using WebApplication1.Models;

namespace Hackathon.Models
{
    public class RootObject
    {
        public string apiVersion { get; set; }
        public Meta meta { get; set; }
        public Data data { get; set; }
    }
}