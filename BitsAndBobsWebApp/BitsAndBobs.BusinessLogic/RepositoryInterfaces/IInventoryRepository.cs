using BitsAndBobs.BuildModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.BusinessLogic.RepositoryInterfaces
{
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> GetLocationInventory(int id);

        void ReduceStock(int id, int quantity);
    }
}
