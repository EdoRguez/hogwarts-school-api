using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AdmissionApplicationDto
    {
        /// <summary>
        /// Unique ID of the record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the person
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last name of the person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Identification of the person
        /// </summary>
        public long Identification { get; set; }

        /// <summary>
        /// Current age of the person
        /// </summary>
        public short Age { get; set; }

        /// <summary>
        /// Id house to apply, by the moment there are only 4 posible values (1: Gryffindor, 2: Hufflepuff, 3: Ravenclaw, 4: Slytherin)
        /// </summary>
        public int Id_House { get; set; }
        public HouseDto House { get; set; }
    }
}
