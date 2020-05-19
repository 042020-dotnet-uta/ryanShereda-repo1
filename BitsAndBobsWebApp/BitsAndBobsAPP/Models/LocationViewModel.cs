using BitsAndBobs.BuildModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsAndBobs.WebApp.Models
{
    public class LocationViewModel
    {
        public List<Location> Locations { get; set; }

        public string SearchString { get; set; }
    }
}
