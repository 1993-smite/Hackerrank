using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes
{
    public class Geometric
    {
        public static double P(long k, double p)
        {
            if (!(p >= 0 && p <= 1))
                throw new ArgumentException("One of argument is not available");
            return p * Math.Pow(1 - p, k - 1);
        }
    }
}
