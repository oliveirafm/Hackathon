using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Hackathon.Models
{
    public class Product
    {
        [Key]
        public long Index { get; set; }

        [Display(Name = "Serial Number")]
        public int? ProductSerialNumber { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product VAT%")]
        public int? VatPercentage { get; set; }

        public ICollection<ProductCatalogue> ProductCatalogues { get; set; } = new HashSet<ProductCatalogue>();
        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();

    }
}