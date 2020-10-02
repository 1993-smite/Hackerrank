using Statistics.Classes;
using System;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string w = "5 4 3 2 1 5";
            string[] wArr = w.Split(" "); 

            string str = "10 40 30 50 20";
                //"64630 11735 14216 99233 14470 4978 73429 38120 51135 67060";
            string[] arr = str.Split(" ");
            long[] arrLong = new long[arr.Length];

            long[] wLong = new long[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arrLong[i] = long.Parse(arr[i]);
                wLong[i] = long.Parse(wArr[i]);
            }



            //var stat = new RangeStats(arrLong);

            //Console.WriteLine("{0:0.0}",stat.QDx);

            double ma = 0.88;
            double mb = 1.55;

            double costA = 160 + 40 * (ma + Math.Pow(ma, 2));
            double costB = 128 + 40 * (mb + Math.Pow(mb, 2));

            double mx = 20;
            double q = 2;

            var normal = new Normal(20, 2);

            Console.WriteLine("{0:0.000}", Normal.Ro(19.5, mx, q));
            Console.WriteLine("{0:0.000}", Normal.Ro(22, mx, q)- Normal.Ro(20, mx, q));
            Console.WriteLine("{0:0.000}", Math.Round((normal.Ferfx(19.5))*100,2));
            Console.WriteLine("{0:0.000}", normal.Ferfx(22) - normal.Ferfx(20));
            Console.WriteLine("{0:0.000}", costB);
            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }
}
