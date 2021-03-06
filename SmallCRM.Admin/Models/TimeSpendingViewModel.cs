﻿using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class TimeSpendingViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Proje")]
        public Guid ProjectId { get; set; }   
        [Display(Name = "Taslak")]
        public Guid? WorkItemId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Çalışan Adı")]
        public string Worker { get; set; }
        [Display(Name = "Zaman Harcaması")]
        public decimal TimeSpent { get; set; }
        [Display(Name = "Görev Durumu")]
        public WorkItemStatus? WorkItemStatus { get; set; }
        [Display(Name = "Proje Adı")]
        public string ProjectName { get; set; }
        [Display(Name = "Görev Adı")]
        public string WorkItemName { get; set; }
    }
}