using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitsAndBobs.BuildModels
{
    public class Product
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the ID of the product.
		/// </summary>
		[Display(Name = "Product ID")]
		public int ProductID { get; set; }

		/// <summary>
		/// Property for the name of the product.
		/// </summary>
		[Display(Name = "Product Name")]
		[Required]
		public String ProductName { get; set; }

		/// <summary>
		/// Property for the price of the product.
		/// </summary>
		[Display(Name = "Product Price")]
		[Column(TypeName = "decimal(18,2)")]
		public double ProductPrice { get; set; }
	}
}
