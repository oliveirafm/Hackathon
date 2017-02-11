using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class ProductCatalogue
    {
        [Key]
        public int ProductCatalogueId { get; set; }

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