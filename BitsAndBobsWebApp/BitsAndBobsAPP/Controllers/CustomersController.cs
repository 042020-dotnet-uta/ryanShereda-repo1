using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsAndBobs.BuildModels;
using Microsoft.AspNetCore.Mvc;
using BitsAndBobs.Data;
using BitsAndBobs.WebApp.Models;

namespace BitsAndBobs.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            using (var unitOfWork = new UnitOfWork(new BitsAndBobsContext()))
            {
                var customersVM = new CustomersViewModel {
                    Customers = unitOfWork.Customers.GetAll().ToList() 
                };

                return View(customersVM);
            }
        }

        //GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID, CustFirstName, CustLastName, CustUsername")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //add customer to database
            }
            return View(customer);
        }
    }
}