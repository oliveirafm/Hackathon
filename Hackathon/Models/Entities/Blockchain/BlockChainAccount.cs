using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class BlockChainAccount
    {
        public int BlockChainAccountId { get; set; }

        public string AccountName { get; set; }
        public string AccountAddress { get; set; }


        [Required]
        //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression("@^ ((?=.*[a - z])(?=.*[A - Z])(?=.*\\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string AccountPassword { get; set; }

    }
}