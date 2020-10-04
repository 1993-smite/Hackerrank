using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Classes
{
    public class PrimeNumber
    {
        public static List<long> GetPrimesNumber(long num)
        {
            List<long> primeNumberDenominators = new List<long>();

            for (int i = 2; i <= num; i++)
            {
                if (num % i == 0 && IsPrimeNumber(i))
                    primeNumberDenominators.Add(i);
            }


            return primeNumberDenominators;
        }

        public static bool IsPrimeNumber(long num)
        {
            if (num < 2)
                return false;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
