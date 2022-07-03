using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class BranchStaff
    {
        public BranchStaff()
        {
           // Branch = new Branch();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        [Required]
        public string Email { get; set; }
        public String Location { get; set; }
        [Required]
        public int BranchId { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }

    public class UserToken
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
