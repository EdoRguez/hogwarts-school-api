using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class AdmissionApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Name should be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name should only contain letters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Last name should be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Last name should only contain letters")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 9999999999, ErrorMessage = "Identification is required and cannot be greater than 10 digits")]
        public long Identification { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "Age is required and cannot be less than 1 and greater than 99")]
        public short Age { get; set; }

        [Required(ErrorMessage = "House is required")]
        public int Id_House { get; set; }

        [ForeignKey("Id_House")]

        public virtual House House { get; set; }

    }
}
