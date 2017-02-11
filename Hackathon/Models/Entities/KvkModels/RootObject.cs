using WebApplication1.Models;

namespace Lab15.Models
{
    public class RootObject
    {
        public string apiVersion { get; set; }
        public Meta meta { get; set; }
        public Data data { get; set; }
    }
}