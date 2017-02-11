using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class Customer
    {
        [Key]
        public long Index { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public long CompanyIndex { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Customer")]
        [ForeignKey("CustomerCompany")]
        public long? CustomerCompanyIndex { get; set; }
        public virtual Company CustomerCompany { get; set; }



        #region hackathon

        public ICollection<DiversificationPlan> Plans { get; set; } = new HashSet<DiversificationPlan>();

        /// <summary>
        /// Should force last plan to end date
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void addDiversificationPlan(DiversificationPlan plan)
        {
            this.Plans.Add(plan);
        }


        #endregion

    }
}