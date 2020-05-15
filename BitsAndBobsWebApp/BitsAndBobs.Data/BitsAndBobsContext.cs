using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Data
{
    public class BitsAndBobsContext : DbContext
    {
        public BitsAndBobsContext (DbContextOptions<BitsAndBobsContext> options) : base(options)
        {

        }

        public BitsAndBobsContext() { }

        //DbSets go here
        #region DbSets

        #endregion
    }
}
