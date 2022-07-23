using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Product
    {
        public Product()
        {
            ProductPrices = new List<ProductPrice>();
            CourseSchedules = new List<CourseSchedule>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        public string Type { get; set; }
        public string Descripion { get; set; }
        //public int AvailableQuantity { get; set; }
        public string Duration { get; set; }
        [Required]
        public bool IsLicenseProduct { get; set; }
        [Required]
        public string LicenseType { get; set; }
        public string ProtectionType { get; set; }
        public string Comment { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
        public List<ProductPrice> ProductPrices { get; set; }
        public List<CourseSchedule> CourseSchedules { get; set; }
    }

    public class ProductPriceCalculationModel
    {
        public decimal Quantity { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal ProductCost { get; set; }
    }
}
