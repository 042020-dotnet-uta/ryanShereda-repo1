using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsAndBobs.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using BitsAndBobs.Data;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using BitsAndBobs.BuildModels;

namespace BitsAndBobs.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Injects a UnitOfWork into the controller, for easy manipulation of repositories
        /// </summary>
        /// <param name="unitOfWork">injects unitOfWork into controller</param>
        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GET Search/Index
        /// lists all orders, and filters according to params
        /// </summary>
        /// <param name="searchStringCustUsername">Filter by customer username</param>
        /// <param name="searchStringLocation">Filter by location</param>
        /// <returns></returns>
        public IActionResult Index(string searchStringCustUsername, string searchStringLocation)
        {
            var orders = _unitOfWork.Orders.GetFull();

            if (!String.IsNullOrEmpty(searchStringCustUsername))
            {
                orders = orders.Where(s => s.OrderCustomer.CustUsername.ToLower().Contains(searchStringCustUsername.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchStringLocation))
            {
                orders = orders.Where(s => s.OrderLocation.LocationCity.ToLower().Contains(searchStringLocation.ToLower()));
            }

            var searchVM = new SearchViewModel 
            { 
               Orders = orders.ToList()
            };

            return View(searchVM);
        }

        /// <summary>
        /// GET Search/Details
        /// See detailed information about placed orders
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLines = _unitOfWork.Orders.GetLineItems(id.Value).ToList();

            if (orderLines == null)
            {
                return NotFound();
            }

            Console.WriteLine(orderLines.Count());

            //var lineItems = order.OrderLineItems;

            var detailsViewModel = new SearchDetailsViewModel
            {
                LineItems = orderLines
            };

            return View(detailsViewModel);
        }
    }
}