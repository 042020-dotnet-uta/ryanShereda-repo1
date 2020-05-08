using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week3GroupDemo.Models
{
    public class Game
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public String Genre { get; set; }

        public ESRBRating Rating { get; set; }
    }
}
