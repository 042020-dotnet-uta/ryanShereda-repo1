using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Data.DataModels
{
    public class Inventory
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the Inventory ID
		/// </summary>
		public int InventoryID { get; set; }

		/// <summary>
		/// Property for the Inventory location
		/// </summary>
		public Location InventoryLocation { get; set; }

		/// <summary>
		/// Property for the Inventory product
		/// </summary>
		public Product InventoryProduct { get; set; }

		/// <summary>
		/// Property for the quantity of products available at this location
		/// </summary>
		public int QuantityAvailable { get; set; }
	}
}
