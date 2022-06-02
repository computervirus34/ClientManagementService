﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsTaxApplied { get; set; }
        public decimal TaxAmount { get; set; }
        public bool IsDiscountApplied { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal OriginalProductCost { get; set; }
        public string ItemWeight { get; set; }
        public string Comment { get; set; }
    }
}