using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab15.Models
{
    public class TaxPoc2PurchaseCatalogue
    {
        [Key]
        public long Index { get; set; }

        [Display(Name = "Product")]
        [ForeignKey("Product")]
        public long? ProductIndex { get; set; }
        public virtual TaxPoc2Product Product { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public long? CompanyIndex { get; set; }
        public virtual TaxPoc2Company Company { get; set; }
    }
}