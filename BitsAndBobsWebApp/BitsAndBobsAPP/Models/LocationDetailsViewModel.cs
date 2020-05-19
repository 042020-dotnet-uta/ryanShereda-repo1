using BitsAndBobs.BuildModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsAndBobs.WebApp.Models
{
    public class LocationDetailsViewModel
    {
        public Location Loc { get; set; }

        public List<Inventory> FilteredInventory { get; set; }
    }
}
