using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
