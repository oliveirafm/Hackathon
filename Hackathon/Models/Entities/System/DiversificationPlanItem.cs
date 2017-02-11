using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{


    public class DiversificationPlanItem
    {
        [Key]
        public int DiversificationPlanItemId { get; set; }

        [ForeignKey("DiversificationPlan")]
        public int? DiversificationPlanId { get; set; }
        public virtual DiversificationPlan DiversificationPlan { get; set; }

        
        [Display(Name = "Value")]
        public double Value { get; set; }

        [Display(Name = "Type")]
        public valueType Type { get; set; }

        [Display(Name = "Observations")]

        public string Observations { get; set; }


        [ForeignKey("ExchangeService")]
        public int? ExchangeServiceId { get; set; }
        public virtual ExchangeService ExchangeService { get; set; }

        [ForeignKey("ContractedServiceConfiguration")]
        public int? ContractedServiceConfigurationId { get; set; }
        public virtual ContractedServiceConfiguration ContractedServiceConfiguration { get; set; }

    }
}