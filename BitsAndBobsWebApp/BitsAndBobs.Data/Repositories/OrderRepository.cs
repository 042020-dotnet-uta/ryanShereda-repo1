using BitsAndBobs.BuildModels;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public BitsAndBobsContext db
        {
            get { return Context as BitsAndBobsContext; }
        }
    }
}
