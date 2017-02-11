using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class DiversificationPlan
    {
        [Key]
        public long Index { get; set; }

        [ForeignKey("Company")]
        public long? CompanyIndex { get; set; }
        public virtual TaxPoc2Company Company { get; set; }

        
        [Display(Name = "Valid From"), Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "Valid To")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Observations")]
        public string Observations { get; set; }

        public ICollection<DiversificationPlanItem> Itens { get; set; } = new HashSet<DiversificationPlanItem>();

        /// <summary>
        /// Should see if its bellow or equal to 100%
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool addDiversificationItem(DiversificationPlanItem item)
        {
            return true;
        }
    }
}