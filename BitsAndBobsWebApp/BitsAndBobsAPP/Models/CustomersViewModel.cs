using BitsAndBobs.BuildModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsAndBobs.WebApp.Models
{
    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; }

        public string SearchStringFirst { get; set; }

        public string SearchStringLast { get; set; }

        public string SearchStringUsername { get; set; }
    }
}
