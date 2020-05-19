using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedLib
{
    public class FruitService : IFruit
    {
        public static int fruitCount = 0;

        public int Add(int n1)
        {
            fruitCount += n1;
            return fruitCount;
        }

        public int Get()
        {
            return fruitCount;
        }

        public int Subtract(int n1)
        {
            fruitCount -= n1;
            return fruitCount;
        }
    }
}
