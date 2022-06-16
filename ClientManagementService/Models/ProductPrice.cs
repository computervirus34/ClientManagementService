using System;
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
        public int  ProductId { get; set; }
        public int CurrencyId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool GSTApplicable { get; set; }
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? StopDate { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}
