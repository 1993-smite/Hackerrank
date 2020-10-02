using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes
{
    public class Poisson
    {
        public static double P(double mx, long x)
        {
            return (Math.Pow(mx, x) /x.Factorial()) * Math.Pow(Math.E, -mx);
        }
    }
}
