﻿using Statistics.Classes;
using System;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string w = "1 2 3 4 5";
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
                


            var stat = new WeightedMean(wLong,arrLong);

            Console.WriteLine(string.Format("{0:0.0}", stat.Mean));

            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }
}
