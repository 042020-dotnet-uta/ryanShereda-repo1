using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsAndBobs.BuildModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BitsAndBobs.Data;
using BitsAndBobs.WebApp.Models;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;

namespace BitsAndBobs.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchStringFirst, string searchStringLast, string searchStringUsername)
        {
            var customers = _unitOfWork.Customers.GetAll();

            if (!String.IsNullOrEmpty(searchStringFirst))
            {
                customers = customers.Where(s => s.CustFirstName.ToLower().Contains(searchStringFirst.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchStringLast))
            {
                customers = customers.Where(s => s.CustLastName.ToLower().Contains(searchStringLast.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchStringUsername))
            {
                customers = customers.Where(s => s.CustUsername.ToLower().Contains(searchStringUsername.ToLower()));
            }

            var customersVM = new CustomersViewModel {
                Customers = customers.ToList()
            };

            return View(customersVM);
            
        }

        //GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerID, CustFirstName, CustLastName, CustUsername")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.Customers.IsAvailable(customer.CustUsername))
                {
                    _unitOfWork.Customers.Add(customer);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                //else
                //username is not unique, so reject input
                //return to view with cleared username field and "unavailable" message?
            }
            return View(customer);
        }
    }
}