using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week3GroupDemo.Models;

namespace Week3GroupDemo.Data
{
    public class MvcGameContext : DbContext
    {
        public MvcGameContext(DbContextOptions<MvcGameContext> options) : base(options)
        {

        }

        public DbSet<Game> Game { get; set; }
        public DbSet<ESRBRating> Rating { get; set; }
    }
}
