using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public class AdmissionApplicationParameters
    {
        /// <summary>
        /// Filter by admission name
        /// </summary>
        public string SearchName { get; set; }

        /// <summary>
        /// Filter by admission last name
        /// </summary>
        public string SearchLastName { get; set; }

        /// <summary>
        /// Filter by initial age
        /// </summary>
        public short? InitAge { get; set; }

        /// <summary>
        /// Filter by end age
        /// </summary>
        public short? EndAge { get; set; }

        /// <summary>
        /// Filter by initial identification
        /// </summary>
        public long? InitIdentification { get; set; }

        /// <summary>
        /// Filter by end identification
        /// </summary>
        public long? EndIdentification { get; set; }

        /// <summary>
        /// Filter by id house, by the moment there are only 4 posible values (1: Gryffindor, 2: Hufflepuff, 3: Ravenclaw, 4: Slytherin)
        /// </summary>

        public int? IdHouse { get; set; }
    }
}
