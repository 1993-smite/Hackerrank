using System;

namespace StringSum
{
    class Program
    {
        public static string sumStrings(string a, string b)
        {
            string result = "";
            int maxX = Math.Max(a.Length, b.Length);

            int index = 1;
            double sum = 0;
            for (int x = maxX; x > 0; x--, index++)
            {
                var aa = a.Length >= index ? a[a.Length - index] : '0';
                var bb = b.Length >= index ? b[b.Length - index] : '0';

                sum = sum > 9 ? 1 : 0;
                sum += char.GetNumericValue(aa) + char.GetNumericValue(bb);

                if (x == 1)
                    result = (int)sum + result;
                else
                    result = (int)sum % 10 + result;
            }

            return result.TrimStart('0');
        }

        static void Main(string[] args)
        {
            Console.WriteLine(sumStrings("123", "456"));
            Console.WriteLine(sumStrings("1230", "456"));
            Console.WriteLine(sumStrings("123", "786"));
            Console.WriteLine(sumStrings("423", "786"));

            Console.WriteLine("Hello World!");
        }
    }
}
