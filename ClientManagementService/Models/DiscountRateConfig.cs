using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class DiscountRateConfig
    {
        [Key]
        public int Id { get; set; }
        public string LicenseType { get; set; }
        public int SlabFrom { get; set; }
        public int SlabTo { get; set; }
        public decimal DiscountRate { get; set; }
        public string IsActive { get; set; }
        [JsonIgnore]
        public DateTime CreatedOn { get; set; }
    }
}
