using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class ContractedServiceConfiguration
    {
        [Key]
        public int ContractedServiceConfigurationId { get; set; }

        [ForeignKey("ExchangeAccount")]
        public int? ExchangeAccountId { get; set; }
        public virtual ExchangeAccount ExchangeAccount { get; set; }

        [ForeignKey("ExchangeService")]
        public int? ExchangeServiceId { get; set; }
        public virtual ExchangeService ExchangeService { get; set; }

        public string ExchangeServiceParameter1 { get; set; }
        public string ExchangeServiceParameter2 { get; set; }
        public string ExchangeServiceParameter3 { get; set; }
        public string ExchangeServiceParameter4 { get; set; }
        public string ExchangeServiceParameter5 { get; set; }
    }
}