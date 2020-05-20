using BitsAndBobs.BuildModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.BusinessLogic.RepositoryInterfaces
{
    public interface IOrderLineItemRepository : IRepository<OrderLineItem>
    {
        IEnumerable<OrderLineItem> GetByOrder(int orderID);
    }
}
