using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab15.Models
{
    public class TaxPoc2BankAccount
    {
        [Key]
        public long Index { get; set; }

        [ForeignKey("Company")]
        public long? CompanyIndex { get; set; }
        public virtual TaxPoc2Company Company { get; set; }

        [Display(Name = "Account Company")]
        public string OwnerCompanyName { get; set; }

        [Display(Name = "Account Balance")]
        public decimal? AccountBalance { get; set; }

        [Display(Name = "Country of Activity")]
        public Country IssuerCompanyActivityCountry { get; set; }

        public string OwnerBlockChainAddress { get; set; }

    }
}