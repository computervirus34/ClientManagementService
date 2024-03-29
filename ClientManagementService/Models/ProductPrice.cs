﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class ProductPrice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int  ProductId { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public bool GSTApplicable { get; set; }
        public string DiscountType { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? StopDate { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [JsonIgnore]
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}
