using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public bool IsTaxApplied { get; set; }
        public decimal TaxAmount { get; set; }
        public bool IsDiscountApplied { get; set; }
        public decimal DiscountAmount { get; set; }
        [Required]
        public decimal OriginalProductCost { get; set; }
        public string ItemWeight { get; set; }
        public string Comment { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
