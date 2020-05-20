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
using Microsoft.Extensions.Logging;

namespace BitsAndBobs.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomersController> _logger;

        /// <summary>
        /// Injects a UnitOfWork into the controller, for easy manipulation of repositories
        /// </summary>
        /// <param name="unitOfWork">injects unitOfWork into controller</param>
        public CustomersController(IUnitOfWork unitOfWork, ILogger<CustomersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
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
                try
                {
                    if (_unitOfWork.Customers.IsAvailable(customer.CustUsername))
                    {
                        _unitOfWork.Customers.Add(customer);
                        _unitOfWork.Complete();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation("Error: Username already in use.");
                }
            }
            return View(customer);
        }
    }
}