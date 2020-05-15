using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Data.DataModels
{
    public class Location
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the Location's ID
		/// </summary>
		public int LocationID { get; set; }

		/// <summary>
		/// Property for the Location's street address
		/// </summary>
		public String LocationAddress { get; set; }

		/// <summary>
		/// Property for the Location's State
		/// </summary>
		public LocationState LocationState { get; set; }

		/// <summary>
		/// Property for the Location's Country
		/// </summary>
		public LocationCountry LocationCountry { get; set; }
	}
}
