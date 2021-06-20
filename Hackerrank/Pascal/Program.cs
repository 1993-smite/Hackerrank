using System;

namespace Pascal
{
    class Program
    {
        public static long OddNumbers(long n)
        {
            // TODO
            return 2 * (n - 1) + 1;
        }

        public static long rowSumOddNumbers(long n)
        {
            // TODO
            var begin = n * (n - 1) + 1;
            long sum = 0;
            int count = 1;
            while (count <= n)
            {
                sum += begin + (count - 1) * 2;
                count++;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(rowSumOddNumbers(4));
        }
    }
}
