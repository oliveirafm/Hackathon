using System.Collections.Generic;

namespace Hackathon.Models
{
    public class Data
    {
        public int itemsPerPage { get; set; }
        public int startPage { get; set; }
        public int totalItems { get; set; }
        public string nextLink { get; set; }
        public List<Item> items { get; set; }
    }
}