using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Account Company")]
        public string OwnerCompanyName { get; set; }

        [Display(Name = "Account Balance")]
        public decimal? AccountBalance { get; set; }

        [Display(Name = "Country of Activity")]
        public Country IssuerCompanyActivityCountry { get; set; }

        public string OwnerBlockChainAddress { get; set; }

        public double? currentYearPensionRetained { get; set; }

        public double? accumulatedPensionSavings { get; set; }
        
        public double? currentYearTaxRetained { get; set; }
           
        public double? currentYearRentingRetained { get; set; }
         
    }
}