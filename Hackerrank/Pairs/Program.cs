using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    class Program
    {

        static int getVal(List<int> sortedArr, int checkVal, int fromIndex = 0, int toIndex = 0)
        {
            int count = 0;
            for(int i=fromIndex;i < toIndex;i++)
            {
                if (sortedArr[i] == checkVal)
                {
                    count++;
                }
                    
                if (sortedArr[i] > checkVal)
                    break;
            }
            return count;
        }

        // Complete the pairs function below.
        static int pairs(int k, int[] arr)
        {
            int count = 0;
            var sorted = arr.OrderBy(x=>x).ToList();

            for (int i = 0; i < arr.Length - 1; i++)
                count += getVal(sorted, sorted[i] + k, i + 1, arr.Length);

            return count;
        }

        static void Main(string[] args)
        {
            string input = "1 5 3 4 2";
            //"1 2 3 4 10 20 30 40 100 200";
            //"10 100 300 200 1000 20 30";
            int[] arr = input.Split(' ').Select(x => int.Parse(x)).ToArray();
            int k = 2;
            var res = pairs(k, arr);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
