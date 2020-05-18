using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BitsAndBobs.BuildModels
{
    public class Order
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the ID of the order.
		/// </summary>
		[Display(Name = "Order ID")]
		public int OrderID { get; set; }

		/// <summary>
		/// Property for the Customer ID of the order.
		/// </summary>
		[Display(Name = "Order Customer")]
		[Required]
		public Customer OrderCustomer { get; set; }

		/// <summary>
		/// Property for the Location of the order.
		/// </summary>
		[Display(Name = "Order Location")]
		[Required]
		public Location OrderLocation { get; set; }

		/// <summary>
		/// Property for the date of the order.
		/// </summary>
		[Display(Name = "Order Date")]
		[DataType(DataType.Date)]
		public DateTime OrderDate { get; set; }

		/// <summary>
		/// Property for the Order Line Items associated with this order
		/// </summary>
		[Display(Name = "Order Line Items")]
		public List<OrderLineItem> OrderLineItems { get; set; }
	}
}
