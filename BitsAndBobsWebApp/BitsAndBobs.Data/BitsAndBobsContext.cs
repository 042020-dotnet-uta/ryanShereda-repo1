using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BitsAndBobs.Data.DataModels;

namespace BitsAndBobs.Data
{
    public class BitsAndBobsContext : DbContext
    {
        public BitsAndBobsContext (DbContextOptions<BitsAndBobsContext> options) : base(options)
        {

        }

        public BitsAndBobsContext() { }

        //DbSets go here
        #region DbSets
        public DbSet<Product> ProductsDB { get; set; }
        public DbSet<Customer> CustomersDB { get; set; }
        public DbSet<OrderLineItem> OrderLineItemsDB { get; set; }
        public DbSet<Order> OrdersDB { get; set; }
        public DbSet<Location> LocationsDB { get; set; }
        public DbSet<Inventory> InventoryDB { get; set; }
        #endregion
    }
}
