using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsFromOffer { get; set; }
        public int OfferId { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public string CustomerCurrency { get; set; }
        public string ArticleNumber { get; set; }
        public string LicenseNumber { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal NetworkSurcharge { get; set; }
        public decimal SoftwareMaintenance { get; set; }
        public decimal ManualDiscount { get; set; }
        [Required]
        public decimal OriginalOrderTotal { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
