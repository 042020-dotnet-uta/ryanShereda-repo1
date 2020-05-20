using BitsAndBobs.BuildModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsAndBobs.WebApp.Models
{
    public class SearchDetailsViewModel
    {
        public List<OrderLineItem> LineItems { get; set; }
    }
}
