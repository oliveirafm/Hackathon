using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Customer")]
        [ForeignKey("CustomerCompany")]
        public int? CustomerCompanyId { get; set; }
        public virtual Company CustomerCompany { get; set; }


    }
}