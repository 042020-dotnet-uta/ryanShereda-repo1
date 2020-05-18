using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsAndBobs.BuildModels;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var customersVM = new CustomersViewModel {
                Customers = _unitOfWork.Customers.GetAll().ToList() 
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