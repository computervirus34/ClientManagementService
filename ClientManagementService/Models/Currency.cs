using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Currency
    {
        public Currency()
        {
            Clients = new List<Client>();
        }
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        [JsonIgnore]
        public List<Client> Clients { get; set; }
    }
}
