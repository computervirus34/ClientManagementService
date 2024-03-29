﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementService.Models
{
    public class DiscountRateConfig
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        [Required]
        public string LicenseType { get; set; }
        [Required]
        public int SlabFrom { get; set; }
        [Required]
        public int SlabTo { get; set; }
        [Required]
        public decimal DiscountRate { get; set; }
        [Required]
        public string IsActive { get; set; }
        [JsonIgnore]
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
    }
}
