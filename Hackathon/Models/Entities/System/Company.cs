using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Hackathon.Models
{
    public class Company
    {
        [Key]
        public int Index { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Vat Number")]
        public int? VatNumber { get; set; }

        [Display(Name = "Country of Activity")]
        public Country? CompanyActivityCountry { get; set; }        

        [Display(Name = "Activity")]
        public CompanyActivityType? CompanyActivity { get; set; }

        [Display(Name = "Sector")]
        public CompanySectorType? CompanySector { get; set; }

        [Display(Name = "KVK Number")]
        public string KvkNumber { get; set; }

        [Display(Name = "Branch Number")]
        public string BranchNumber { get; set; }

        [Display(Name = "ID number")]
        public string Rsin { get; set; }

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "SBI Code")]
        public string SbiCode { get; set; }

        [Display(Name = "SBI Code Description")]
        public string SbiCodeDescription { get; set; }

        [Display(Name = "Address Type")]
        public string AddressType { get; set; }

        [Display(Name = "Bag ID")]
        public string BagId { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        [Display(Name = "House Number Addition")]
        public string HouseNumberAddition { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Country Name")]
        public string CompanyCountry { get; set; }

        [Display(Name = "GPS Latitude")]
        public double GPSLatitude { get; set; }

        [Display(Name = "GPS Longitude")]
        public double GPSLongitude { get; set; }

        [Display(Name = "RijksdriehoekX")]
        public double RijksdriehoekX { get; set; }

        [Display(Name = "RijksdriehoekY")]
        public double RijksdriehoekY { get; set; }

        [Display(Name = "RijksdriehoekZ")]
        public double RijksdriehoekZ { get; set; }

        [Display(Name = "Blockchain Address")]
        public string CompanyBlockChainAddress { get; set; }

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public ICollection<BankMovement> BankMovements { get; set; } = new HashSet<BankMovement>();

        public ICollection<CompanyDepartment> CompanyDepartments { get; set; } = new HashSet<CompanyDepartment>();

        #region hackathon

        [Display(Name = "Diversification Plans History"), Required]
        public ICollection<DiversificationPlan> Plans { get; set; } = new HashSet<DiversificationPlan>();

        /// <summary>
        /// Should force last plan to end date
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void addDiversificationPlan(DiversificationPlan plan)
        {
            this.Plans.Add(plan);
        }

        [Display(Name = "IBAN"), Required]
        public string IBAN { get; set; }

        #endregion

    }
}