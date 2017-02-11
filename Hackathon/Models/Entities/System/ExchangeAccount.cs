using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class ExchangeAccount
    {
        [Key]
        public int ExchangeAccountId { get; set; }

        //ForeignKey to AspIdentityUser, not enforced because it might be a seperate database in the future
        public string UserId { get; set; }


        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }



        public ICollection<DiversificationPlan> Plans { get; set; } = new HashSet<DiversificationPlan>();

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();

        public ICollection<BankMovement> BankMovements { get; set; } = new HashSet<BankMovement>();

    }
}