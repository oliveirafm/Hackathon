using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hackathon.Models
{
    public class BankMovement
    {
        [Key]
        public int BankMovementId { get; set; }

        [ForeignKey("ExchangeAccount")]
        public int? ExchangeAccountId { get; set; }
        public virtual ExchangeAccount ExchangeAccount { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Deposit Amount")]
        public decimal? AmountDeposit { get; set; }
        [Display(Name = "Deposit Source")]
        public String SourceDeposit { get; set; }

        public string SourceDepositRef { get; set; }

        [Display(Name = "Withdrawal Amount")]
        public decimal? AmountWithdrawal { get; set; }
        [Display(Name = "Withdrawal Source")]
        public String DestinationWithdrawal { get; set; }

        public string DestinationWithdrawalRef { get; set; }

    }
}