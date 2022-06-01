using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Branch
    {
        public Branch()
        {
            BranchStaffs = new List<BranchStaff>();
            Clients = new List<Client>();
        }
        [Key]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string ManagerName { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public List<BranchStaff> BranchStaffs { get; set; }
        [JsonIgnore]
        public List<Client> Clients { get; set; }

    }
}
