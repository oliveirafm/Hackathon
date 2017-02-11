using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TradeNames
    {
        public string businessName { get; set; }
        public string shortBusinessName { get; set; }
        public List<string> currentTradeNames { get; set; }
        public List<string> currentStatutoryNames { get; set; }
    }
}