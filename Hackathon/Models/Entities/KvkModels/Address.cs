namespace Hackathon.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Address
    {
        public string type { get; set; }
        public string bagId { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string houseNumberAddition { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public double gpsLatitude { get; set; }
        public double gpsLongitude { get; set; }
        public double rijksdriehoekX { get; set; }
        public double rijksdriehoekY { get; set; }
        public double rijksdriehoekZ { get; set; }
    }
}