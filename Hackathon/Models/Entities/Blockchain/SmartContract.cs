using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class SmartContract
    {

        [Key]
        public int SmartContractId { get; set; }

        public string ContractName { get; set; }

        public string ContractByteCode { get; set; }
        public string ContractAbi { get; set; }
        public string ContractCode { get; set; }

        public string ContractAddress { get; set; }
        public string ContractOwnerAddress { get; set; }

        [ForeignKey("BlockChainDeployAccount")]
        public int? BlockChainAccountId { get; set; }
        public virtual BlockChainAccount BlockChainDeployAccount { get; set; }

    }
}