using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hackathon.Models
{
    public class BankMovement
    {
        [Key]
        public long Index { get; set; }

        [ForeignKey("Company")]
        public long? CompanyIndex { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Deposit Amount")]
        public decimal? AmountDeposit { get; set; }
        [Display(Name = "Deposit Source")]
        public String SourceDeposit { get; set; }
        public long? SourceDepositIndex { get; set; }

        [Display(Name = "Withdrawal Amount")]
        public decimal? AmountWithdrawal { get; set; }
        [Display(Name = "Withdrawal Source")]
        public String DestinationWithdrawal { get; set; }
        public long? DestinationWithdrawalIndex { get; set; }

        [Display(Name = "Is VAT")]
        public bool isTaxationTransaction { get; set; }

    }
}