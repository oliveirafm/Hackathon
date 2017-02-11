using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{

    public enum valueType { Value, Percentage};

    public class DiversificationPlanItem
    {
        [Key]
        public long Index { get; set; }

        [ForeignKey("DiversificationPlan")]
        public long? DiversificationPlanIndex { get; set; }
        public virtual DiversificationPlan Plan { get; set; }

        
        [Display(Name = "Value")]
        public double Value { get; set; }

        [Display(Name = "Type")]
        public valueType Type { get; set; }

        [Display(Name = "Observations")]
        public string Observations { get; set; }

    }
}