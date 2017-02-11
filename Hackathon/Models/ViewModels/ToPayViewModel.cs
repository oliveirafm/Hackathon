using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hackathon.Models.ViewModels
{
    public class ToPayViewModel
    {

            [Required]
            [Display(Name = "IBAN")]
            public string IBAN { get; set; }

            [Required]
            [Display(Name = "Invoice Number")]
            public string InvoiceNumber { get; set; }

            [Display(Name = "Ammount")]
            public decimal Ammount { get; set; }
    }
}