using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public string Type { get; set; }
        public string Descripion { get; set; }
        public int AvailableQuantity { get; set; }
        public string Duration { get; set; }
        public bool IsLicenseProduct { get; set; }
        public string LicenseType { get; set; }
        public string ProtectionType { get; set; }
        public string Comment { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }

    }
}
