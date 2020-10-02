using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static long arrayManipulation(int n, int[,] queries)
        {
            long result = 0;
            var arr = new long[n];
            /*for (int i = 0; i < n; i++)
                arr.Add(0);*/

            for(int index = 0; index < queries.GetLength(0); index++)
            {
                //for(int i = queries[index,0] - 1; i < queries[index,1]; i++)
                //{
                //    arr[i] += queries[index, 2];
                //    if (result < arr[i])
                //    {
                //        result = arr[i];
                //    }
                //}
                arr[queries[index, 0] - 1] += queries[index, 2];
                arr[queries[index, 1]] += -queries[index, 2];

                //Console.WriteLine(string.Join(", ", arr));
            }
            Console.WriteLine(string.Join(", ", arr));

            long item = 0;
            for(int i=0; i < arr.Length; i++)
            {
                item += arr[i];
                result = Math.Max(item, result);
            }

            //result = arr.Max(x=>x);

            return result;
        }

        static void Main(string[] args)
        {
            //int[,] q = new int[3,3] { {1, 5, 3}, {4, 8, 7}, {6, 9, 1} };
            int[,] q = new int[4, 3] { { 2, 6, 8 }, { 3, 5, 7 }, { 1, 8, 1 }, { 5, 9, 15 } };
            Console.WriteLine(q.Rank);
            Console.WriteLine(q.GetLength(0));
            Console.WriteLine(q.LongLength);
            var res = arrayManipulation(10, q);

            Console.WriteLine(res);
            Console.ReadLine();

        }
    }
}
