using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class House
    { 
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(10, ErrorMessage = "House name should be less than 10 characters")]
        public string Name { get; set; }

        public virtual ICollection<AdmissionApplication> ListAdmissionApplications { get; set; }
    }
}
