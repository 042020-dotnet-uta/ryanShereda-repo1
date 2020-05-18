using BitsAndBobs.BuildModels;
using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BitsAndBobs.Data.Repositories
{
    class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BitsAndBobsContext context) : base(context)
        {

        }

        public void Add(Customer customer)
        {
            Context.Set<Customer>().Add(customer);
        }

        public bool IsAvailable(string custUsername)
        {
            var available =
                ((from check in db.CustomersDB
                 where (check.CustUsername == custUsername)
                 select check).Count() == 0);
            return available;
        }

        public BitsAndBobsContext db
        {
            get { return Context as BitsAndBobsContext; }
        }

    }
}
