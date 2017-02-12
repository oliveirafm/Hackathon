using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models.ViewModels
{
    public class CurrentAccountViewModel
    {
        public decimal Amount { get; set; }
        public string Account { get; set; }
        public int CompanyId { get; set; }

    }
}