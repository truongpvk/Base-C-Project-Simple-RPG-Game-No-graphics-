using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public static class RandomNumberGenerator
    {
        private static Random _generator = new Random();

        public static int NumberBetween(int minimum, int maximum)
        {
            return _generator.Next(minimum, maximum + 1);
        }
    }
}
