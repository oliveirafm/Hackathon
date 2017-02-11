using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class TransactionLog
    {
        [Key]
        public int TransactionLogId { get; set; }

        public DateTime LogDate { get; set; }

        public string CalledService { get; set; }
        public string CalledFunction { get; set; }
        public string CalledParameters { get; set; }

        public string ReturnedValue { get; set; }

    }
}