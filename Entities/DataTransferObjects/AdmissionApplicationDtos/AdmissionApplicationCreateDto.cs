using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AdmissionApplicationCreateDto
    {
        /// <summary>
        /// Name of the person
        /// </summary>
        [Required]
        [MaxLength(20, ErrorMessage = "Name should be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name should only contain letters")]
        public string Name { get; set; }

        /// <summary>
        /// Last name of the person
        /// </summary>
        [Required]
        [MaxLength(20, ErrorMessage = "Last name should be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Last name should only contain letters")]
        public string LastName { get; set; }

        /// <summary>
        /// Identification of the person
        /// </summary>
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Identification is required cannot be greater than 10 digits")]
        public long Identification { get; set; }

        /// <summary>
        /// Current age of the person
        /// </summary>
        [Required]
        [Range(1, 99, ErrorMessage = "Age is required and cannot be less than 1 and greater than 99")]
        public short Age { get; set; }

        /// <summary>
        /// Id house to apply, by the moment there are only 4 posible values (1: Gryffindor, 2: Hufflepuff, 3: Ravenclaw, 4: Slytherin)
        /// </summary>
        [Required(ErrorMessage = "House is required")]
        public int Id_House { get; set; }
    }
}
