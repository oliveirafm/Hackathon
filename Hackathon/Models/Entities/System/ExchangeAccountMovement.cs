using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models.Entities.System
{
    public class ExchangeAccountMovement
    {
        [Key]
        public int ExchangeAccountMovementId { get; set; }

        [ForeignKey("ExchangeAccount")]
        public int? ExchangeAccountId { get; set; }
        public virtual ExchangeAccount ExchangeAccount { get; set; }

        [ForeignKey("SourceInvoice")]
        public int? InvoiceId { get; set; }
        public virtual Invoice SourceInvoice { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Deposit Amount")]
        public decimal? AmountDeposit { get; set; }
        [Display(Name = "Deposit Source")]
        public String SourceDeposit { get; set; }


        [ForeignKey("DiversificationPlanItem")]
        public int? DiversificationPlanItemId { get; set; }
        public virtual DiversificationPlanItem DiversificationPlanItem { get; set; }

        [Display(Name = "Withdrawal Amount")]
        public decimal? AmountWithdrawal { get; set; }
        [Display(Name = "Withdrawal Source")]
        public String DestinationWithdrawal { get; set; }

        [ForeignKey("ExchangeService")]
        public int? ExchangeServiceId { get; set; }
        public virtual ExchangeService ExchangeService { get; set; }

        [ForeignKey("ContractedServiceConfiguration")]
        public int? ContractedServiceConfigurationId { get; set; }
        public virtual ContractedServiceConfiguration ContractedServiceConfiguration { get; set; }

    }
}