﻿using System;

namespace MaxArraySum
{
    class Program
    {
        static int maxSubsetSum(int[] arr)
        {
            if (arr.Length == 0) return 0;
            arr[0] = Math.Max(0, arr[0]);
            if (arr.Length == 1) return arr[0];
            arr[1] = Math.Max(arr[0], arr[1]);
            for (int i = 2; i < arr.Length; i++)
                arr[i] = Math.Max(arr[i - 1], arr[i] + arr[i - 2]);
            return arr[arr.Length - 1];
        }

        static void Main(string[] args)
        {
            int[] arr = { 3, 5, -7, 8, 10 };

            Console.WriteLine(maxSubsetSum(arr));
            Console.ReadLine();
        }
    }
}
