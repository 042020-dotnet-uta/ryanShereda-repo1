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
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BitsAndBobs.WebApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LocationsController> _logger;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="unitOfWork"></param>
        public LocationsController(IUnitOfWork unitOfWork, ILogger<LocationsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// GET: Locations/Index
        /// Index action for Locations controller
        /// </summary>
        /// <param name="searchString">the string to filter locations by</param>
        /// <returns>filtered view</returns>
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
                    try
                    {
                        if (lovm.Quantity1 > 0)
                        {
                            if (lovm.Quantity1 > filteredInventory[0].QuantityAvailable)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            var line1 = new OrderLineItem()
                            {
                                LineItemProduct = filteredInventory[0].InventoryProduct,
                                Quantity = lovm.Quantity1,
                                LinePrice = (filteredInventory[0].InventoryProduct.ProductPrice * lovm.Quantity1)
                            };
                            newOrder.OrderLineItems.Add(line1);
                            _unitOfWork.Inventories.ReduceStock(filteredInventory[0].InventoryID, lovm.Quantity1);
                        }

                        if (lovm.Quantity2 > 0)
                        {
                            if (lovm.Quantity2 > filteredInventory[1].QuantityAvailable)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            newOrder.OrderLineItems.Add(new OrderLineItem()
                            {
                                LineItemProduct = filteredInventory[1].InventoryProduct,
                                Quantity = lovm.Quantity2,
                                LinePrice = (filteredInventory[1].InventoryProduct.ProductPrice * lovm.Quantity2)
                            });
                            _unitOfWork.Inventories.ReduceStock(filteredInventory[1].InventoryID, lovm.Quantity2);
                        }

                        if (lovm.Quantity3 > 0)
                        {
                            if (lovm.Quantity3 > filteredInventory[2].QuantityAvailable)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            newOrder.OrderLineItems.Add(new OrderLineItem()
                            {
                                LineItemProduct = filteredInventory[2].InventoryProduct,
                                Quantity = lovm.Quantity3,
                                LinePrice = (filteredInventory[2].InventoryProduct.ProductPrice * lovm.Quantity3)
                            });
                            _unitOfWork.Inventories.ReduceStock(filteredInventory[2].InventoryID, lovm.Quantity3);
                        }

                        if (lovm.Quantity4 > 0)
                        {
                            if (lovm.Quantity4 > filteredInventory[3].QuantityAvailable)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            newOrder.OrderLineItems.Add(new OrderLineItem()
                            {
                                LineItemProduct = filteredInventory[3].InventoryProduct,
                                Quantity = lovm.Quantity4,
                                LinePrice = (filteredInventory[3].InventoryProduct.ProductPrice * lovm.Quantity4)
                            });
                            _unitOfWork.Inventories.ReduceStock(filteredInventory[3].InventoryID, lovm.Quantity4);
                        }

                        if (lovm.Quantity5 > 0)
                        {
                            if (lovm.Quantity5 > filteredInventory[4].QuantityAvailable)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            newOrder.OrderLineItems.Add(new OrderLineItem()
                            {
                                LineItemProduct = filteredInventory[4].InventoryProduct,
                                Quantity = lovm.Quantity5,
                                LinePrice = (filteredInventory[4].InventoryProduct.ProductPrice * lovm.Quantity5)
                            });
                            _unitOfWork.Inventories.ReduceStock(filteredInventory[4].InventoryID, lovm.Quantity5);
                        }

                        _unitOfWork.Orders.Add(newOrder);
                        _unitOfWork.Complete();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception e)
                    {
                        //log out order too high
                        _logger.LogInformation("Error: order value out of range.");
                    }
                }
            }

            

            return View(lovm);
        }
    }
}
