using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab15.Models
{
    public class SmartContract
    {

        [Key]
        public int ContractId { get; set; }

        public string ContractName { get; set; }
        public string ContractFileName { get; set; }
        public int ParametersCount { get; set; }
        public string ParametersTypes { get; set; }
        public string ContractByteCode { get; set; }
        public string Abi { get; set; }
        public string ContractAddress { get; set; }
        public string ContractOwnerAddress { get; set; }
        public string ContractCode { get; set; }
        
    }
}