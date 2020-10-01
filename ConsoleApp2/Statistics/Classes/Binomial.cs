using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes
{
    public static class MathExtension
    {
        public static long Factorial(this long v)
        {
            long res = 1;
            for(int i = 1; i <= v; i++)
            {
                res *= i;
            }
            return res;
        }

        public static long CountCombination(this long n, long k)
        {
            long res = n.Factorial() / (k.Factorial() * (n - k).Factorial());
            return res;
        }
    }



    public class Binomial
    {
        public static double P(long n, long k, double p)
        {
            if (!(p >= 0 && p <= 1))
                throw new ArgumentException("One of argument is not available");
            return n.CountCombination(k) * Math.Pow(p, k) * Math.Pow(1 - p, n - k);
        }
    }
}
