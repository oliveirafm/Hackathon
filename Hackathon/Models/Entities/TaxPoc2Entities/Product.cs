using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lab15.Models
{
    public class TaxPoc2Product
    {
        [Key]
        public long Index { get; set; }

        [Display(Name = "Serial Number")]
        public int? ProductSerialNumber { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product VAT%")]
        public int? VatPercentage { get; set; }

        public ICollection<TaxPoc2ProductCatalogue> ProductCatalogues { get; set; } = new HashSet<TaxPoc2ProductCatalogue>();
        public ICollection<TaxPoc2Invoice> Invoices { get; set; } = new HashSet<TaxPoc2Invoice>();

    }
}