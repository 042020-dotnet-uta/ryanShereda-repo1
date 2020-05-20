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

        public IActionResult Index(string searchStringUsername, string searchStringLocation)
        {
            var orders = _unitOfWork.Orders.GetFull();

            var searchVM = new SearchViewModel 
            { 
               Orders = orders.ToList()
            };

            return View(searchVM);
        }
    }
}