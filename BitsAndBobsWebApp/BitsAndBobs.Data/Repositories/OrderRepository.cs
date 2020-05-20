using BitsAndBobs.BuildModels;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBobs.Data.Repositories
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BitsAndBobsContext context) : base(context)
        {

        }

        public void Add(Order order)
        {
            Context.Set<Order>().Add(order);
        }

        public IEnumerable<Order> GetFull()
        {
            var orders = db.OrdersDB
                .Include(loc => loc.OrderLocation)
                .Include(cust => cust.OrderCustomer);

            return orders.ToList();
        }

        public BitsAndBobsContext db
        {
            get { return Context as BitsAndBobsContext; }
        }
    }
}
