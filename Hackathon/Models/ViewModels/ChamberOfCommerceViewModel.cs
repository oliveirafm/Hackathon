using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class ChamberOfCommerceViewModel
    {
        public Company Company { get; set; }

        public List<Company> Companies { get; set; }

        public Item SelectedItem { get; set; }

        public IEnumerable<Item> SearchResult { get; set; }


        public bool CompanyIsSelected { get; set; }

        public string CompanySearchName { get; set; }


        //public long Index { get; set; }
        public int? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int VatNumber { get; set; }

        public Country CompanyActivityCountry { get; set; }

        public CompanyActivityType CompanyActivity { get; set; }

        public CompanySectorType CompanySector { get; set; }

        public string KvkNumber { get; set; }

        public string BranchNumber { get; set; }

        public string Rsin { get; set; }

        public string BusinessName { get; set; }

        public string SbiCode { get; set; }

        public string SbiCodeDescription { get; set; }

        public string AddressType { get; set; }

        public string BagId { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string HouseNumberAddition { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string CompanyCountry { get; set; }

        public double GPSLatitude { get; set; }

        public double GPSLongitude { get; set; }

        public double RijksdriehoekX { get; set; }

        public double RijksdriehoekY { get; set; }

        public double RijksdriehoekZ { get; set; }

        public string CompanyBlockChainAddress { get; set; }
    }
}