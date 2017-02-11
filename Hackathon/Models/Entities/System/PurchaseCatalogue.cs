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
        public int PurchaseCatalogueId { get; set; }

        [Display(Name = "Product")]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}