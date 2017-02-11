using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class InvoicePaymentDivision
    {
        
        [Key]
        public int InvoicePaymentDivisionId { get; set; }

        [ForeignKey("Invoice")]
        public int? InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        [Display(Name = "Value")]
        public double Value { get; set; }

        [ForeignKey("ContractedServiceConfiguration")]
        public int? ContractedServiceConfigurationId { get; set; }
        public virtual ContractedServiceConfiguration ContractedServiceConfiguration { get; set; }


    }
}