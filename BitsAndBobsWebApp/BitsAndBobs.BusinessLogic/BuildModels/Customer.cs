using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBobs.BuildModels
{
    public class Customer
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the Customer ID (unique)
		/// </summary>
		[Display(Name = "Customer ID")]
		public int CustomerID { get; set; }

		/// <summary>
		/// Property for the Customer's first name
		/// </summary>
		[Display(Name = "Customer First Name")]
		[RegularExpression(@"[a-zA-Z""'\s-]*$")]
		[Required]
		public String CustFirstName { get; set; }

		/// <summary>
		/// Property for the Customer's last name
		/// </summary>
		[Display(Name = "Customer Last Name")]
		[RegularExpression(@"[a-zA-Z""'\s-]*$")]
		[Required]
		public String CustLastName { get; set; }

		/// <summary>
		/// Property for the Customer's username
		/// </summary>
		[Display(Name = "Customer Username")]
		[RegularExpression(@"[a-zA-Z0-9""'\s-]*$")]
		[Required]
		public String CustUsername { get; set; }

		#region Constructors
		//      //Empty constructor
		//      public Customer() { }

		////fully-realized constructor
		//public Customer(String firstName, String lastName, String userName)
		//{
		//	CustFirstName = firstName;
		//	CustLastName = lastName;
		//	CustUsername = userName;
		//}
		#endregion
	}
}
