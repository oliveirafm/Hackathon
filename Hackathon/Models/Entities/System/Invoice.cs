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


        [Display(Name = "VAT Number")]
        public int? IssuerVatNumber { get; set; }

        [ForeignKey("IssuerCompany")]
        [Display(Name = "Company")]
        public int? IssuerCompanyId { get; set; }
        public virtual Company IssuerCompany { get; set; }


        
        public int? IssueDateTimestamp { get; set; }
        [Display(Name = "Issue Date")]
        public DateTime? IssueDate { get; set; }

   
        public int? DueDateTimestamp { get; set; }
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }


        [Display(Name = "Product / Service"), Required]
        public string PaymentService { get; set; }

        [Display(Name = "Price"), Required]
        public decimal? PaymentValue { get; set; }

        [Display(Name = "Hours")]
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

        [Display(Name = "Total Price")]
        public decimal? InvoiceValue { get; set; }
        [Display(Name = "VAT Value")]
        public decimal? InvoiceVatValue { get; set; }
        [Display(Name = "VAT%")]
        public int? InvoiceVatPercentage { get; set; }
        [Display(Name = "Status")]
        public InvoiceStatus InvoiceStatus { get; set; }


        [Display(Name = "Payment Divisions"), Required]
        public ICollection<InvoicePaymentDivision> PaymentDivisions { get; set; } = new HashSet<InvoicePaymentDivision>();
    }
}