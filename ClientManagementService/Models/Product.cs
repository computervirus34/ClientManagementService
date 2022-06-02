using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCategoryId { get; set; }
        public string Type { get; set; }
        public string Descripion { get; set; }
        public string Quantity { get; set; }
        public string Duration { get; set; }
        public bool IsLicenseProduct { get; set; }
        public string LicenseType { get; set; }
        public string ProtectionType { get; set; }
        public string Comment { get; set; }

    }
}
