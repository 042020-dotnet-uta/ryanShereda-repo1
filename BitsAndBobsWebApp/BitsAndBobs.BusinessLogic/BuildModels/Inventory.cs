using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBobs.BuildModels
{
    public class Inventory
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the Inventory ID
		/// </summary>
		[Display(Name = "Inventory ID")]
		public int InventoryID { get; set; }

		/// <summary>
		/// Property for the Inventory location
		/// </summary>
		[Display(Name = "Inventory Location")]
		public Location InventoryLocation { get; set; }

		/// <summary>
		/// Property for the Inventory product
		/// </summary>
		[Display(Name = "Inventory Product")]
		public Product InventoryProduct { get; set; }

		/// <summary>
		/// Property for the quantity of products available at this location
		/// </summary>
		[Display(Name = "Quantity Available")]
		public int QuantityAvailable { get; set; }
	}
}
