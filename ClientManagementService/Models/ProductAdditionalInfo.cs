using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class ProductAdditionalInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public bool Admin { get; set; }
        public string UserName { get; set; }
        public string LicenseType { get; set; }
        public string ProtectionType { get; set; }
        public int NumberOfPlaces { get; set; }
        public bool IsSmallBusiness { get; set; }
        [JsonIgnore]
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
