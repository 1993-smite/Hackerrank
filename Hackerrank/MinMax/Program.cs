using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{

    class Program
    {
        
        // Complete the maxMin function below.
        static int maxMin(int k, int[] arr)
        {
            var sorted = arr.OrderBy(x=>x).ToList();

            int min = int.MaxValue;
            int ki = k - 1;

            for(int i = 0; i < arr.Length - ki; i++)
            {
                var diff = sorted[i + ki] - sorted[i];
                if (diff < min)
                {
                    min = diff;
                }
            }

            return min;
        }

        static void Main(string[] args)
        {
            string input = "10 100 300 200 1000 20 30";
                //"1 2 3 4 10 20 30 40 100 200";
                //"10 100 300 200 1000 20 30";
            int[] arr = input.Split(' ').Select(x => int.Parse(x)).ToArray();
            int k = 3;
            var res = maxMin(k, arr);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
