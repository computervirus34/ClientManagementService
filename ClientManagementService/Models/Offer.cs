using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public int ClientID { get; set; }
        public int BranchId { get; set; }
        public DateTime OfferDate { get; set; }
        public string Decription { get; set; }
        public string CustomerCurrency { get; set; }
        public decimal OfferTotal { get; set; }
        public decimal OfferTax { get; set; }
        public decimal OfferDiscount { get; set; }
        public string CreatedBy { get; set; }
    }
}
