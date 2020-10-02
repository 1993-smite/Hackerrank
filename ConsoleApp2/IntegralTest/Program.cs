using Integral;
using System;

namespace IntegralTest
{
    class Program
    {
        public static double f(double x)
        {
            return x * x;
        }

        static void Main(string[] args)
        {
            double res = RectangleIntegration.Integration(0, 0.0001, 1, f);

            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
