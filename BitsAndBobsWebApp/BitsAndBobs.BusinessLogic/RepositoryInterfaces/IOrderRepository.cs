using BitsAndBobs.BuildModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.BusinessLogic.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Add(Order order);

        IEnumerable<Order> GetFull();
    }
}
