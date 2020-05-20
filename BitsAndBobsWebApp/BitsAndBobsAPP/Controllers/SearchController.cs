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

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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