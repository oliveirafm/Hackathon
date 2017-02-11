using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class BlockChainAccount
    {
        public int BlockChainAccountId { get; set; }

        public string AccountName { get; set; }
        public string AccountAddress { get; set; }
        public string AccountPassword { get; set; }
        public int? AccountCompanyId { get; set; }
        public string AccountType { get; set; }

    }
}