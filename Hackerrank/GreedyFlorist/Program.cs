using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyFlorist
{
    class Program
    {
        // Complete the getMinimumCost function below.
        static int getMinimumCost(int k, int[] c)
        {
            int result = 0;
            var sortedBack = c.OrderByDescending(x=>x).ToArray();
            int indexBuy = 0;
            int count = c.Length;

            for(int i = 0; i < count; i++)
            {
                result += sortedBack[i] * (1 + indexBuy / k);
                indexBuy++;
            }

            return result;
        }

        static void Main(string[] args)
        {
            string input = "2 5 6";
            var arr = input.Split(' ').Select(x => int.Parse(x)).ToList();
            int k = 3;
            var res = getMinimumCost(k, arr.ToArray());

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
