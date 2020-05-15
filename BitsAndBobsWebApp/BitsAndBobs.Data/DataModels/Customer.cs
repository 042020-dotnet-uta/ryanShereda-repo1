using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Data.DataModels
{
    public class Customer
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the Customer ID (unique)
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// Property for the Customer's first name
		/// </summary>
		public String CustFirstName { get; set; }

		/// <summary>
		/// Property for the Customer's last name
		/// </summary>
		public String CustLastName { get; set; }

		/// <summary>
		/// Property for the Customer's username
		/// </summary>
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
