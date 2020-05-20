using System;
using System.Collections.Generic;
using System.Text;
using BitsAndBobs.BuildModels;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using BitsAndBobs.Data.Repositories;

//Unit of Work details derived from Programming with Mosh video
//https://www.youtube.com/watch?v=rtXpYpZdOzM
namespace BitsAndBobs.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BitsAndBobsContext _context;

        public UnitOfWork(BitsAndBobsContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Locations = new Repository<Location>(_context);
            Inventories = new InventoryRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public IRepository<Location> Locations { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IInventoryRepository Inventories { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
