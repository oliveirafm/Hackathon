using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class ExchangeService
    {
        [Key]
        public int ExchangeServiceId { get; set; }

        [Display(Name = "Service")]
        public string ExchangeServiceName { get; set; }

        public bool AvailableInMarket { get; set; }

        [ForeignKey("ServiceSmartContract")]
        public int? SmartContractId { get; set; }
        public virtual SmartContract ServiceSmartContract { get; set; }
    }
}