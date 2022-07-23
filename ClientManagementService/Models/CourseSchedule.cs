using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientManagementService.Models
{
    public class CourseSchedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime Datetime { get; set; }
        public string CourseContent { get; set; }
        public string Venue { get; set; }
        public string Mode { get; set; }
        public string CreatedOn { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
