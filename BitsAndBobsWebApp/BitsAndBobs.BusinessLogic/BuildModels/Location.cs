using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BitsAndBobs.BuildModels
{
    public class Location
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the Location's ID
		/// </summary>
		[Display(Name = "Location ID")]
		public int LocationID { get; set; }

		/// <summary>
		/// Property for the Location's street address
		/// </summary>
		[Display(Name = "Location City")]
		public String LocationCity { get; set; }
	}
}
