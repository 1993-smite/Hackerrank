using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;

namespace HashTablesIceCreamParlor
{
    class Program
    {
        // Complete the whatFlavors function below.
        static void whatFlavors(int[] cost, int money)
        {
            int summ = 0;
            var dicCost = new Hashtable();

            for(int i = 0; i < cost.Length; i++)
            {
                summ = money - cost[i];

                if (summ < 1)
                    continue;

                if (dicCost.ContainsKey(summ))
                {
                    Console.WriteLine($"{dicCost[summ]} {i + 1}");
                    return;
                }
                else
                {
                    if (!dicCost.ContainsKey(cost[i]))
                        dicCost.Add(cost[i], i+1);
                }
            }
        }

        static void Main(string[] args)
        {
            var arr = Common.StrToInt("20 10 2 2 4 3").ToArray();
            var money = 4;
            whatFlavors(arr, money);

            //Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
