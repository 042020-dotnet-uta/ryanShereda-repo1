using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Data.DataModels
{
    public class Order
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the ID of the order.
		/// </summary>
		public int OrderID { get; set; }

		/// <summary>
		/// Property for the Customer ID of the order.
		/// </summary>
		public Customer OrderCustomer { get; set; }

		/// <summary>
		/// Property for the Location of the order.
		/// </summary>
		public Location OrderLocation { get; set; }

		/// <summary>
		/// Property for the date of the order.
		/// </summary>
		public DateTime OrderDate { get; set; }
	}
}
