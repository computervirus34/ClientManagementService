using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public bool IsAtive { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? StopDate { get; set; }
    }
}
