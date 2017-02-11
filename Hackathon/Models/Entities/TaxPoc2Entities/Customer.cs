using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab15.Models
{
    public class TaxPoc2Customer
    {
        [Key]
        public long Index { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public long CompanyIndex { get; set; }
        public virtual TaxPoc2Company Company { get; set; }

        [Display(Name = "Customer")]
        [ForeignKey("CustomerCompany")]
        public long? CustomerCompanyIndex { get; set; }
        public virtual TaxPoc2Company CustomerCompany { get; set; }

    }
}