using Statistics.Classes;
using Statistics.Classes.MNK;
using System;
using System.Collections.Generic;

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


            List<double> x = new List<double>();
            List<double> y = new List<double>();

            List<double> y1 = new List<double>();

            for (int i = 1; i < 10; i++)
            {
                x.Add(i);
                y.Add( (8 + 3 * i) / (-4));
                y1.Add((7 + 4 * i) / (-3));
            }

            var r1 = new RangeStats(y.ToArray());
            var r2 = new RangeStats(y1.ToArray());

            Console.WriteLine("{0:0.000}", r1.CorrelatePirson(r2));
            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }
}
