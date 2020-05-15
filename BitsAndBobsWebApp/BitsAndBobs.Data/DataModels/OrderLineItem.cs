using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Data.DataModels
{
    public class OrderLineItem
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the ID of the line item.
		/// </summary>
		public int OrderLineItemID { get; set; }

		/// <summary>
		/// Property for the Order ID of the item.
		/// </summary>
		public Order LineItemOrder { get; set; }

		/// <summary>
		/// Property for the Product ID of the line item.
		/// </summary>
		public Product LineItemProduct { get; set; }

		/// <summary>
		/// Property for the quantity of the line item.
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// Property for the total price of the line item.
		/// </summary>
		public double LinePrice { get; set; }
	}
}
