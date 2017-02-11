using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class PurchaseCatalogue
    {
        [Key]
        public long Index { get; set; }

        [Display(Name = "Product")]
        [ForeignKey("Product")]
        public long? ProductIndex { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public long? CompanyIndex { get; set; }
        public virtual Company Company { get; set; }
    }
}