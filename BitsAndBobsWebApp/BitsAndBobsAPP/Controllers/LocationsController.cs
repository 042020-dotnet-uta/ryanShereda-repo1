using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BitsAndBobs.WebApp.Models;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BitsAndBobs.WebApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index(string searchString)
        {
            var locations = _unitOfWork.Locations.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                locations = locations.Where(s => s.LocationCity.ToLower().Contains(searchString.ToLower()));
            }

            var locationsVM = new LocationViewModel
            {
                Locations = locations.ToList()
            };

            return View(locationsVM);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = _unitOfWork.Locations.Get(id.Value);
            
            if (location == null)
            {
                return NotFound();
            }

            var inventories = _unitOfWork.Inventories.GetLocationInventory(id.Value);

            var locationDetailsVM = new LocationDetailsViewModel {
                Loc = location,
                FilteredInventory = inventories.ToList()
            };

            return View(locationDetailsVM);
        }

        //GET: Locations/Order
        public IActionResult Order(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventories = _unitOfWork.Inventories.GetLocationInventory(id.Value);

            var locationOrderViewModel = new LocationOrderViewModel
            {
                Loc = _unitOfWork.Locations.Get(id.Value),
                Customers = new SelectList(_unitOfWork.Customers.GetAll()),
                FilteredInventory = inventories.ToList(),
                Quantity1 = 0,
                Quantity2 = 0,
                Quantity3 = 0,
                Quantity4 = 0,
                Quantity5 = 0
            };

            return View(locationOrderViewModel);
        }

        //POST: Locations/Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order()
        {
            return View();
        }
    }
}
