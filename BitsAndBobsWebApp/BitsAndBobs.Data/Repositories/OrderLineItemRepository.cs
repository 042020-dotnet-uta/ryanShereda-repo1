using BitsAndBobs.BuildModels;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitsAndBobs.Data.Repositories
{
    class OrderLineItemRepository : Repository<OrderLineItem>, IOrderLineItemRepository
    {
        public OrderLineItemRepository(BitsAndBobsContext context) : base(context)
        {

        }

        

        public BitsAndBobsContext db
        {
            get { return Context as BitsAndBobsContext; }
        }

        public IEnumerable<OrderLineItem> GetByOrder(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}
