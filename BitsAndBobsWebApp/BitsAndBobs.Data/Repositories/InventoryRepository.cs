using BitsAndBobs.BusinessLogic.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BitsAndBobs.BuildModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBobs.Data.Repositories
{
    class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(BitsAndBobsContext context) : base(context)
        {

        }

        public IEnumerable<Inventory> GetLocationInventory(int id)
        {
            var inventories = db.InventoryDB
                .Include(loc => loc.InventoryLocation)
                .Include(prod => prod.InventoryProduct)
                .Where(loc => loc.InventoryLocation.LocationID == id);
             
            return inventories;
        }

        public void ReduceStock(int id, int quantity)
        {
            var temp = db.InventoryDB.Find(id);
            try
            {
                if (temp.QuantityAvailable < quantity || quantity < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                temp.QuantityAvailable -= quantity;
            }
            catch (ArgumentOutOfRangeException e)
            {
                //log out exception
            }
            catch (Exception e)
            {
                //log out general exception
            }
            
        }

        public BitsAndBobsContext db
        {
            get { return Context as BitsAndBobsContext; }
        }
    }
}
