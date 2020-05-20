using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BitsAndBobs.WebApp.Models;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using BitsAndBobs.BuildModels;

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
                LocID = _unitOfWork.Locations.Get(id.Value).LocationID,
                Customers = new SelectList(_unitOfWork.Customers.GetAllUsernames()),
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
        public IActionResult Order([Bind("LocID, OrderCustomerUsername, Quantity1, Quantity2, Quantity3, Quantity4, Quantity5")]LocationOrderViewModel lovm)
        {
            var newOrder = new Order()
            {
                OrderLocation = _unitOfWork.Locations.Get(lovm.LocID),
                OrderDate = DateTime.Today,
                OrderLineItems = new List<OrderLineItem>()
            };

            var filteredInventory = _unitOfWork.Inventories.GetLocationInventory(lovm.LocID).ToList();

            if (!(lovm.OrderCustomerUsername == "No selection"))
            {
                var tempCust = _unitOfWork.Customers.GetByUsername(lovm.OrderCustomerUsername);
                newOrder.OrderCustomer = tempCust;

                if ((lovm.Quantity1 > 0) || (lovm.Quantity2 > 0) || (lovm.Quantity3 > 0) || (lovm.Quantity4 > 0) || (lovm.Quantity5 > 0))
                {
                    var line1 = new OrderLineItem() 
                        { 
                            LineItemProduct = filteredInventory[0].InventoryProduct,
                            Quantity = lovm.Quantity1,
                            LinePrice = (filteredInventory[0].InventoryProduct.ProductPrice * lovm.Quantity1) 
                        };
                    newOrder.OrderLineItems.Add(line1);
                    _unitOfWork.Inventories.ReduceStock(filteredInventory[0].InventoryID, lovm.Quantity1);

                    newOrder.OrderLineItems.Add(new OrderLineItem() 
                    { 
                        LineItemProduct = filteredInventory[1].InventoryProduct,
                        Quantity = lovm.Quantity2,
                        LinePrice = (filteredInventory[1].InventoryProduct.ProductPrice * lovm.Quantity2) 
                    });
                    _unitOfWork.Inventories.ReduceStock(filteredInventory[1].InventoryID, lovm.Quantity2);
                    newOrder.OrderLineItems.Add(new OrderLineItem() 
                    { 
                        LineItemProduct = filteredInventory[2].InventoryProduct,
                        Quantity = lovm.Quantity3,
                        LinePrice = (filteredInventory[2].InventoryProduct.ProductPrice * lovm.Quantity3) 
                    });
                    _unitOfWork.Inventories.ReduceStock(filteredInventory[2].InventoryID, lovm.Quantity3);
                    newOrder.OrderLineItems.Add(new OrderLineItem() 
                    { 
                        LineItemProduct = filteredInventory[3].InventoryProduct,
                        Quantity = lovm.Quantity4,
                        LinePrice = (filteredInventory[3].InventoryProduct.ProductPrice * lovm.Quantity4) 
                    });
                    _unitOfWork.Inventories.ReduceStock(filteredInventory[3].InventoryID, lovm.Quantity4);
                    newOrder.OrderLineItems.Add(new OrderLineItem() 
                    { 
                        LineItemProduct = filteredInventory[4].InventoryProduct,
                        Quantity = lovm.Quantity5,
                        LinePrice = (filteredInventory[4].InventoryProduct.ProductPrice * lovm.Quantity5) 
                    });
                    _unitOfWork.Inventories.ReduceStock(filteredInventory[4].InventoryID, lovm.Quantity5);

                    _unitOfWork.Orders.Add(newOrder);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
            }

            

            return View(lovm);
        }
    }
}
