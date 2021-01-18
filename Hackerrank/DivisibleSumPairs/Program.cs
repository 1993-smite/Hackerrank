using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleSumPairs
{
    class Program
    {
        // Complete the divisibleSumPairs function below.
        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int count = 0;

            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            string input = "1 3 2 6 1 2";
            var arr = input.Split(' ').Select(x => int.Parse(x)).ToList();
            int k = 3;
            var res = divisibleSumPairs(arr.Count,k,arr.ToArray());

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
