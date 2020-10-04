using Mathematics.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    class Program
    {
        static List<long> arr = new List<long>();

        static int primeCount(long n)
        {
            int max = 0;
            decimal res = 1;
            for(long i=1; i <= n; i++)
            {
                if (PrimeNumber.IsPrimeNumber(i))
                {
                    res = res * i;
                    if (res <= n)
                    {
                        max++;
                        arr.Add(i);
                    }  
                    else
                        break;
                }
            }
            return max;
        }

        /*
     * Complete the connectingTowns function below.
     */
        static int connectingTowns(int n, int[] routes)
        {
            /*
             * Write your code here.
             */
            int count = 1;
            for (int i = 0; i < routes.Length; i++)
            {
                count *= routes[i];
                count %= 1234567;
            }
            return count;
        }

        static decimal T(long n)
        {
            /*
             * Write your code here.
             */
            return n * n + (n - 1) * (n - 1);
        }

        /*
         * Complete the summingSeries function below.
         */
        static int summingSeries(long n)
        {
            return (int)(((n % 1000000007) * (n % 1000000007)) % 1000000007);

        }

        static void Main(string[] args)
        {
            string str = "3 784 945 778 736 252 406 796 252 621 298 513 826 159 " +
                "396 502 818 820 959 826 880 728 729 26 665 609 31 711 950 908 " +
                "50 203 940 863 662 476 50 733 825 871 234 133 395 680 95 290 125 " +
                "909 361 593 946 534 133 798 305 266 683 856 876 446 510 900 947 254 " +
                "228 101 445 125 729 559 632 978 224 767 151 290 481 912 462 638 892 " +
                "823 570 718 129 699 602 965 838 943 355 968 779 928";

            int[] routes = Array.ConvertAll(str.Split(' '), x => int.Parse(x));

            //Console.WriteLine(connectingTowns(1, routes));
            Console.WriteLine(summingSeries(5351871996120528));
            Console.ReadLine();
        }
    }
}
