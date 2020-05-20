using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsAndBobs.BuildModels;

namespace BitsAndBobs.WebApp.Models
{
    public class SearchViewModel
    {
        public List<Order> Orders { get; set; }

        public string SearchStringLocation { get; set; }
        public string SearchStringCustUsername { get; set; }

    }
}
