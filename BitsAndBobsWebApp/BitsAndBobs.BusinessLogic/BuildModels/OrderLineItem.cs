using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitsAndBobs.BuildModels
{
    public class OrderLineItem
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the ID of the line item.
		/// </summary>
		[Display(Name = "Order Line Item ID")]
		public int OrderLineItemID { get; set; }

		///// <summary>
		///// Property for the Order ID of the item.
		///// </summary>
		//[Display(Name = "Line Item Order")]
		//public Order LineItemOrder { get; set; }

		/// <summary>
		/// Property for the Product ID of the line item.
		/// </summary>
		[Display(Name = "Line Item Product")]
		[Required]
		public Product LineItemProduct { get; set; }

		/// <summary>
		/// Property for the quantity of the line item.
		/// </summary>
		[Display(Name = "Line Item Quantity")]
		public int Quantity { get; set; }

		/// <summary>
		/// Property for the total price of the line item.
		/// </summary>
		[Display(Name = "Line Item Total Price")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public double LinePrice { get; set; }
	}
}
