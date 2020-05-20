using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using BitsAndBobs.BuildModels;
using System.Linq;
using BitsAndBobs.Data.Repositories;
using BitsAndBobs.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace BitsAndBobs.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test1DB")
                .Options;

            //Act
            Customer testCustomer;

            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                _unitOfWork.Customers.Add(testCustomer);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var customer = context.CustomersDB
                    .Where(cust => cust.CustUsername == "AAdmin").FirstOrDefault();
                Assert.Equal(testCustomer.CustUsername, customer.CustUsername);
            }
        }

        [Fact]
        public void TestGetCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test2DB")
                .Options;

            //Act
            Customer testCustomer;

            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                _unitOfWork.Customers.Add(testCustomer);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                

                Assert.Equal(testCustomer.CustUsername, _unitOfWork.Customers.Get(1).CustUsername);
            }
        }

        [Fact]
        public void TestGetAllCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test3DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                var testCustomer2 = new Customer
                {
                    CustFirstName = "Becky",
                    CustLastName = "Boss",
                    CustUsername = "BossBabe"
                };

                _unitOfWork.Customers.Add(testCustomer);
                _unitOfWork.Customers.Add(testCustomer2);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(2, _unitOfWork.Customers.GetAll().Count());
            }
        }

        [Fact]
        public void TestUsernameAvailableTrue()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test4DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                _unitOfWork.Customers.Add(testCustomer);
                
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.True(_unitOfWork.Customers.IsAvailable("TestUsername"));
                
            }
        }

        [Fact]
        public void TestUsernameAvailableFalse()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test5DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                _unitOfWork.Customers.Add(testCustomer);

                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.False(_unitOfWork.Customers.IsAvailable("AAdmin"));

            }
        }

        [Fact]
        public void TestGetAllUsernames()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test6DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                var testCustomer2 = new Customer
                {
                    CustFirstName = "Bonnie",
                    CustLastName = "Badmin",
                    CustUsername = "BBadmin"
                };

                _unitOfWork.Customers.Add(testCustomer);
                _unitOfWork.Customers.Add(testCustomer2);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                

                Assert.Equal(2, _unitOfWork.Customers.GetAllUsernames().Count());

            }
        }

        [Fact]
        public void TestGetByUsername()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test7DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                _unitOfWork.Customers.Add(testCustomer);

                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal("AAdmin", _unitOfWork.Customers.GetByUsername("AAdmin").CustUsername);

            }
        }

        [Fact]
        public void TestGetLocationInventory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test8DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(2, _unitOfWork.Inventories.GetLocationInventory(1).Count());

            }
        }

        [Fact]
        public void TestReduceStock()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test9DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                _unitOfWork.Inventories.ReduceStock(1, 1);

                Assert.Equal(4, _unitOfWork.Inventories.GetLocationInventory(1).Where(id => id.InventoryID == 1).FirstOrDefault().QuantityAvailable);

            }
        }

        [Fact]
        public void TestReduceMultipleStock()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test10DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                _unitOfWork.Inventories.ReduceStock(1, 1);
                _unitOfWork.Inventories.ReduceStock(2, 3);

                Assert.Equal(4, _unitOfWork.Inventories.GetLocationInventory(1).Where(id => id.InventoryID == 1).FirstOrDefault().QuantityAvailable);
                Assert.Equal(2, _unitOfWork.Inventories.GetLocationInventory(1).Where(id => id.InventoryID == 2).FirstOrDefault().QuantityAvailable);

            }
        }

        [Fact]
        public void TestAddOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test11DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "Test"
                };

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                var testOrderLineItem = new OrderLineItem
                {
                    LineItemProduct = testProduct1,
                    LinePrice = 2,
                    Quantity = 2
                };

                var testOrder = new Order
                {
                    OrderCustomer = testCustomer,
                    OrderDate = DateTime.Now,
                    OrderLineItems = new List<OrderLineItem> { testOrderLineItem },
                    OrderLocation = testLocation
                };

                context.Add(testCustomer);
                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();

                _unitOfWork.Orders.Add(testOrder);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                

                Assert.Equal(1, _unitOfWork.Orders.GetAll().Count());

            }
        }

        [Fact]
        public void TestGetFullOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test12DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "Test"
                };

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                var testOrderLineItem = new OrderLineItem
                {
                    LineItemProduct = testProduct1,
                    LinePrice = 2,
                    Quantity = 2
                };

                var testOrder = new Order
                {
                    OrderCustomer = testCustomer,
                    OrderDate = DateTime.Now,
                    OrderLineItems = new List<OrderLineItem> { testOrderLineItem },
                    OrderLocation = testLocation
                };

                context.Add(testCustomer);
                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();

                _unitOfWork.Orders.Add(testOrder);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(1, _unitOfWork.Orders.GetFull().Count());

            }
        }

        [Fact]
        public void TestGetLineItems()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test13DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "Test"
                };

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                var testOrderLineItem = new OrderLineItem
                {
                    LineItemProduct = testProduct1,
                    LinePrice = 2,
                    Quantity = 2
                };

                var testOrder = new Order
                {
                    OrderCustomer = testCustomer,
                    OrderDate = DateTime.Now,
                    OrderLineItems = new List<OrderLineItem> { testOrderLineItem },
                    OrderLocation = testLocation
                };

                context.Add(testCustomer);
                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();

                _unitOfWork.Orders.Add(testOrder);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(1, _unitOfWork.Orders.GetLineItems(1).Count());

            }
        }

        [Fact]
        public void TestGetOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test14DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "Test"
                };

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                var testOrderLineItem = new OrderLineItem
                {
                    LineItemProduct = testProduct1,
                    LinePrice = 2,
                    Quantity = 2
                };

                var testOrder = new Order
                {
                    OrderCustomer = testCustomer,
                    OrderDate = DateTime.Now,
                    OrderLineItems = new List<OrderLineItem> { testOrderLineItem },
                    OrderLocation = testLocation
                };

                context.Add(testCustomer);
                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();

                _unitOfWork.Orders.Add(testOrder);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(1, _unitOfWork.Orders.Get(1).OrderID);

            }
        }

        [Fact]
        public void TestGetLocation()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test15DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "Test"
                };

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                var testOrderLineItem = new OrderLineItem
                {
                    LineItemProduct = testProduct1,
                    LinePrice = 2,
                    Quantity = 2
                };

                var testOrder = new Order
                {
                    OrderCustomer = testCustomer,
                    OrderDate = DateTime.Now,
                    OrderLineItems = new List<OrderLineItem> { testOrderLineItem },
                    OrderLocation = testLocation
                };

                context.Add(testCustomer);
                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();

                _unitOfWork.Orders.Add(testOrder);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(1, _unitOfWork.Locations.Get(1).LocationID);

            }
        }

        [Fact]
        public void TestGetAllLocations()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test16DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "Test"
                };

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testLocation2 = new Location
                {
                    LocationCity = "Peoria"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                var testOrderLineItem = new OrderLineItem
                {
                    LineItemProduct = testProduct1,
                    LinePrice = 2,
                    Quantity = 2
                };

                var testOrder = new Order
                {
                    OrderCustomer = testCustomer,
                    OrderDate = DateTime.Now,
                    OrderLineItems = new List<OrderLineItem> { testOrderLineItem },
                    OrderLocation = testLocation
                };

                context.Add(testCustomer);
                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testLocation2);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();

                _unitOfWork.Orders.Add(testOrder);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(2, _unitOfWork.Locations.GetAll().Count());

            }
        }

        [Fact]
        public void TestCheckProduct()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test17DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "Test"
                };

                var testProduct1 = new Product
                {
                    ProductName = "Apple",
                    ProductPrice = 1
                };

                var testProduct2 = new Product
                {
                    ProductName = "Banana",
                    ProductPrice = 1
                };

                var testLocation = new Location
                {
                    LocationCity = "Springfield"
                };

                var testInventory1 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct1,
                    QuantityAvailable = 5
                };

                var testInventory2 = new Inventory
                {
                    InventoryLocation = testLocation,
                    InventoryProduct = testProduct2,
                    QuantityAvailable = 5
                };

                var testOrderLineItem = new OrderLineItem
                {
                    LineItemProduct = testProduct1,
                    LinePrice = 2,
                    Quantity = 2
                };

                var testOrder = new Order
                {
                    OrderCustomer = testCustomer,
                    OrderDate = DateTime.Now,
                    OrderLineItems = new List<OrderLineItem> { testOrderLineItem },
                    OrderLocation = testLocation
                };

                context.Add(testCustomer);
                context.Add(testProduct1);
                context.Add(testProduct2);
                context.Add(testLocation);
                context.Add(testInventory1);
                context.Add(testInventory2);

                context.SaveChanges();

                _unitOfWork.Orders.Add(testOrder);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal("Apple", _unitOfWork.Inventories.GetLocationInventory(1).Where(id => id.InventoryID == 1).FirstOrDefault().InventoryProduct.ProductName);

            }
        }

        [Fact]
        public void TestSaveMultipleChanges()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BitsAndBobsContext>()
                .UseInMemoryDatabase(databaseName: "Test18DB")
                .Options;

            //Act
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCustomer = new Customer 
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "AAdmin"
                };

                var testCustomer2 = new Customer
                {
                    CustFirstName = "Bonnie",
                    CustLastName = "Boss",
                    CustUsername = "BossBabe"
                };

                var testCustomer3 = new Customer
                {
                    CustFirstName = "Charlie",
                    CustLastName = "Champion",
                    CustUsername = "Champ"
                };

                _unitOfWork.Customers.Add(testCustomer);
                _unitOfWork.Customers.Add(testCustomer2);
                _unitOfWork.Customers.Add(testCustomer3);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new BitsAndBobsContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);



                Assert.Equal(3, _unitOfWork.Customers.GetAll().Count());

            }
        }
    }
}
