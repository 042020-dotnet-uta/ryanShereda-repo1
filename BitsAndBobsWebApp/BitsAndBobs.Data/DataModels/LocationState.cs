using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Data.DataModels
{
    public class LocationState
    {
        /// <summary>
        /// Primary Key -- 
        /// Property for the Location State's ID.
        /// </summary>
        public int LocationStateID { get; set; }

        /// <summary>
        /// Property for the location's State
        /// </summary>
        public String State { get; set; }
    }
}
