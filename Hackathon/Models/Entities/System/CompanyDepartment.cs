﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class CompanyDepartment
    {
        [Key]
        public long Index { get; set; }

        [Display(Name = "Department Name")]
        public string CompanyDepartmentName { get; set; }

        [Display(Name = "Department Head")]
        public string CompanyDepartmentHead { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public long? CompanyIndex { get; set; }
        public virtual Company Company { get; set; }

    }
}