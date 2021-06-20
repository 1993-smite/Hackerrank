using System;

namespace MinArrSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 8, 5, 12, 19, 22 };
            var res = sumTwoSmallestNumbers(numbers);
            Console.WriteLine(res);
        }

        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            //Code here...
            var min = int.MaxValue;
            var min1 = int.MaxValue;

            foreach(var it in numbers)
            {
                if (min1 > it)
                {
                    if (min > it)
                    {
                        min1 = min;
                        min = it;
                        continue;
                    }
                    min1 = it;
                }
            }

            return min + min1;
        }
    }
}
