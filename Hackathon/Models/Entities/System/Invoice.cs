﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Hackathon.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Display(Name = "Issuer Company")]
        public string IssuerCompanyName { get; set; }

        public string IssuerBlockChainAddress { get; set; }

        [Display(Name = "Issuer VAT Number")]
        public int? IssuerVatNumber { get; set; }

        public Country IssuerCompanyActivityCountry { get; set; }

        [ForeignKey("IssuerCompany")]
        public int? IssuerCompanyId { get; set; }
        public virtual Company IssuerCompany { get; set; }


        [Display(Name = "Invoice Number")]
        public int? InvoiceNumber { get; set; }

        [Display(Name = "Invoice Issue Date")]
        public int? IssueDateTimestamp { get; set; }
        public DateTime? IssueDate { get; set; }

        [Display(Name = "Invoice Due Date")]
        public int? DueDateTimestamp { get; set; }
        public DateTime? DueDate { get; set; }



        [Display(Name = "Product Number")]
        public int? ProductNumber { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Value")]
        public decimal? ProductValue { get; set; }

        [Display(Name = "Quantity")]
        public int? ProductQuantity { get; set; }

        [Display(Name = "VAT%")]
        public int? ProductVatPercentage { get; set; }

        [Display(Name = "VAT Value")]
        public decimal? ProductVatValue { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }


        [Display(Name = "Customer Name")]
        public string CustomerCompanyName { get; set; }

        public string CustomerBlockChainAddress { get; set; }

        [Display(Name = "Customer VAT Number")]
        public int? CustomerVatNumber { get; set; }

        [Display(Name = "Customer Country")]
        public Country CustomerCompanyActivityCountry { get; set; }

        [ForeignKey("CustomerCompany")]
        public int? CustomerCompanyId { get; set; }
        public virtual Company CustomerCompany { get; set; }

        [Display(Name = "Invoice Value")]
        public decimal? InvoiceValue { get; set; }
        [Display(Name = "Invoice VAT Value")]
        public decimal? InvoiceVatValue { get; set; }
        [Display(Name = "Invoice VAT%")]
        public int? InvoiceVatPercentage { get; set; }
        [Display(Name = "Invoice Status")]
        public InvoiceStatus InvoiceStatus { get; set; }


        #region hackathon

        [Display(Name = "PlanItens"), Required]
        public ICollection<DiversificationPlanItem> DiversificationPlanItens { get; set; } = new HashSet<DiversificationPlanItem>();



        #endregion
    }
}