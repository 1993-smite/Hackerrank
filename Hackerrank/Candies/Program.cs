using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;

namespace Candies
{
    class Program
    {
        static long candy(int[] arr, int i, long last)
        {
            long item = 1;
            if (arr[i] > arr[i - 1])
            {
                item += last;
            }
            //if (i != arr.Length - 1 && arr[i + 1] > arr[i - 1])
            //{
            //    item++;
            //}
            return item;
        }

        // Complete the candies function below.
        static long candies(int n, int[] arr)
        {
            long count = 1;
            long item = 1;
            var its = new List<long>();
            its.Add(item);

            long countDown = 0;

            for(int i = 1; i < n - 1; i++)
            {
                item = candy(arr, i, item);

                if (arr[i] > arr[i + 1])
                    countDown++;
                else if (arr[i] < arr[i + 1] && countDown > 0)
                {
                    item += (countDown - 1);
                    countDown = 0;
                }
                    
                
                its.Add(item);
                count += item;
            }
            item = candy(arr, n - 1, item);

            if (arr[n-2] > arr[n - 1])
            {
                item += (countDown - 1);
                countDown = 0;
            }

            its.Add(item);
            count += item;

            return count;
        }

        static void Main(string[] args)
        {
            var arr = Common.StrToInt("1 2 2").ToArray();
            var res = candies(arr.Length, arr);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
