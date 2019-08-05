﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class RegionViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "İlçe Adı")]
        public string Name { get; set; }

        [Display(Name = "Şehir")]
        public Guid CityId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name="Şehir Adı")]
        public string CityName { get; set; }
    }
}
