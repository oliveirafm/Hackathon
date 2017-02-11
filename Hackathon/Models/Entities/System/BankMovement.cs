using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hackathon.Models
{
    public class BankMovement
    {
        [Key]
        public int BankMovementId { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Deposit Amount")]
        public decimal? AmountDeposit { get; set; }
        [Display(Name = "Deposit Source")]
        public String SourceDeposit { get; set; }

        public int? SourceDepositId { get; set; }

        [Display(Name = "Withdrawal Amount")]
        public decimal? AmountWithdrawal { get; set; }
        [Display(Name = "Withdrawal Source")]
        public String DestinationWithdrawal { get; set; }

        public int? DestinationWithdrawalId { get; set; }

        [Display(Name = "Is VAT")]
        public bool isTaxationTransaction { get; set; }

    }
}