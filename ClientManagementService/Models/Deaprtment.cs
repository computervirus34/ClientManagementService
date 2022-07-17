using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class Deaprtment
    {
        public Deaprtment()
        {
            BranchStaffs = new List<BranchStaff>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public List<BranchStaff> BranchStaffs { get; set; }
    }
}
