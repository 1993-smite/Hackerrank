using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;

namespace MaximumSubarraySum
{
    class Program
    {

        // Complete the maximumSum function below.
        static long maximumSum(long[] a, long m)
        {
            var arr = new long[a.Length];
            long sum = 0;

            long res = 0;

            for(int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                arr[i] = sum;

                long el = a[i] % m;
                if (el > res)
                {
                    res = el;
                    if (res == m - 1)
                        return res;
                }

                el = arr[i] % m;
                if (el > res)
                {
                    res = el;
                    if (res == m - 1)
                        return res;
                }
                
            }

            int k = 2;
            while(k < a.Length - 1)
            {
                for(int i = 0; i < a.Length - k; i++)
                {
                    for(int j=i+k;j<a.Length; j++)
                    {
                        long el = (arr[j] - arr[i]) % m;
                        if (el > res)
                        {
                            res = el;
                            if (res == m - 1)
                                return res;
                        }
                    }
                }
            }
            

            return res;
        }


        static void Main(string[] args)
        {
            var arr = Common.StrToLong("3 2 13 5 12 9 9 5").ToArray();
            var goal = 7;
            var res = maximumSum(arr, goal);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
