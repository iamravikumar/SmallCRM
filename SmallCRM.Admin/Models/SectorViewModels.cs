﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class SectorViewModels
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name="Sektör")]
        public string Name { get; set; }
    }
}