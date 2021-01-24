using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;

namespace BillDivision
{
    class Program
    {
        // Complete the bonAppetit function below.
        static void bonAppetit(List<int> bill, int k, int b)
        {
            int max = int.MinValue;
            long summ = 0;
            for(int i = 0; i < bill.Count; i++)
            {
                if (i == k) continue;

                summ += bill[i];
            }

            var res = b - summ / 2;

            Console.WriteLine(res == 0 ? "Bon Appetit" : res.ToString());
        }

        static void Main(string[] args)
        {
            var arr = Common.StrToInt("3 10 2 9").ToList();

            bonAppetit(arr, 1, 12);

            Console.ReadLine();
        }
    }
}
