using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int BranchId { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}
