using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BitsAndBobs.BuildModels;

namespace BitsAndBobs.BusinessLogic.RepositoryInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Add(Customer customer);

        bool IsAvailable(string custUsername);
    }
}
