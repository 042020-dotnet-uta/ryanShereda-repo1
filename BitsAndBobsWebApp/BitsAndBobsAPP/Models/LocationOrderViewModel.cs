using BitsAndBobs.BuildModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitsAndBobs.WebApp.Models
{
    public class LocationOrderViewModel
    {
        public int LocID { get; set; }

        public SelectList Customers { get; set; }

        public string OrderCustomerUsername { get; set; }

        public List<Inventory> FilteredInventory { get; set; }

        public int Quantity1 { get; set; }

        public int Quantity2 { get; set; }

        public int Quantity3 { get; set; }

        public int Quantity4 { get; set; }

        public int Quantity5 { get; set; }
    }
}
