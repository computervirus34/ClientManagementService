using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Offer
    {
        public Offer()
        {
            OfferItems = new List<OfferItem>();
        }
        [Key]
        public int Id { get; set; }
        public int ClientID { get; set; }
        public int BranchId { get; set; }
        public DateTime OfferDate { get; set; }
        public string Description { get; set; }
        public string CustomerCurrency { get; set; }
        public decimal OfferTotal { get; set; }
        public decimal OfferTax { get; set; }
        public decimal OfferDiscount { get; set; }
        public decimal OriginalOfferTotal { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public List<OfferItem> OfferItems { get; set; }
    }
}
