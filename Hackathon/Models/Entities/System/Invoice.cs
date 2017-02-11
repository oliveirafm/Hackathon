using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Hackathon.Models
{
    public class Invoice
    {
        [Key]
        [Display(Name = "Invoice Number")]
        public int InvoiceId { get; set; }

        [ForeignKey("ExchangeAccount")]
        public int? ExchangeAccountId { get; set; }
        public virtual ExchangeAccount ExchangeAccount { get; set; }


        [Display(Name = "Issuer VAT Number")]
        public int? IssuerVatNumber { get; set; }

        [ForeignKey("IssuerCompany")]
        [Display(Name = "Issuer Company")]
        public int? IssuerCompanyId { get; set; }
        public virtual Company IssuerCompany { get; set; }


        [Display(Name = "Invoice Issue Date")]
        public int? IssueDateTimestamp { get; set; }
        public DateTime? IssueDate { get; set; }

        [Display(Name = "Invoice Due Date")]
        public int? DueDateTimestamp { get; set; }
        public DateTime? DueDate { get; set; }


        [Display(Name = "Payment Service")]
        public string PaymentService { get; set; }

        [Display(Name = "Payment Value")]
        public decimal? PaymentValue { get; set; }

        [Display(Name = "Payment Service Hours")]
        public decimal? PaymentServiceHours{ get; set; }

        [Display(Name = "VAT%")]
        public int? ProductVatPercentage { get; set; }

        [Display(Name = "VAT Value")]
        public decimal? ProductVatValue { get; set; }


        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer VAT Number")]
        public int? CustomerVatNumber { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Invoice Value")]
        public decimal? InvoiceValue { get; set; }
        [Display(Name = "Invoice VAT Value")]
        public decimal? InvoiceVatValue { get; set; }
        [Display(Name = "Invoice VAT%")]
        public int? InvoiceVatPercentage { get; set; }
        [Display(Name = "Invoice Status")]
        public InvoiceStatus InvoiceStatus { get; set; }


        [Display(Name = "Payment Divisions"), Required]
        public ICollection<InvoicePaymentDivision> PaymentDivisions { get; set; } = new HashSet<InvoicePaymentDivision>();
    }
}