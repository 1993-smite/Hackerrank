using System;
using System.Text;

namespace RomanNumbers
{
    static class MathExtension
    {
        public static string toRoman(int number)
        {
            int[] num = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] sym = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            var res = new StringBuilder(); 
            int i = 12;
            while (number > 0)
            {
                int div = number / num[i];
                number = number % num[i];
                while (div-- > 0)
                {
                    res.Append(sym[i]);
                }
                i--;
            }

            return res.ToString();
        }

        private static int getDec(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            if (r == 'C')
                return 100;
            if (r == 'D')
                return 500;
            if (r == 'M')
                return 1000;
            return -1;
        }

        // Finds decimal value of a
        // given romal numeral
        public static int romanToDec(string str)
        {
            // Initialize result
            int res = 0;

            for (int i = 0; i < str.Length; i++)
            {
                // Getting value of symbol s[i]
                int s1 = getDec(str[i]);

                // Getting value of symbol s[i+1]
                if (i + 1 < str.Length)
                {
                    int s2 = getDec(str[i + 1]);

                    if (s1 >= s2) res = res + s1;
                    else
                    {
                        res = res + s2 - s1;
                        i++;
                    }
                }
                else
                {
                    res = res + s1;
                    i++;
                }
            }

            return res;
        }

        public static long NextBiggerNumber(long n)
        {
            var num = n.ToString().ToCharArray();

            var res = findNext(num);

            return res == "nil" ? -1 : long.Parse(res);
        }

        static void swap(char[] ar, int i, int j)
        {
            char temp = ar[i];
            ar[i] = ar[j];
            ar[j] = temp;
        }

        static string findNext(char[] ar)
        {
            int i;
            int n = ar.Length;
            var str = new StringBuilder();

            // I) Start from the right most digit
            // and find the first digit that is smaller
            // than the digit next to it.
            for (i = n - 1; i > 0; i--)
            {
                if (ar[i] > ar[i - 1])
                {
                    break;
                }
            }

            // If no such digit is found, then all
            // digits are in descending order means
            // there cannot be a greater number with
            // same set of digits
            if (i == 0)
            {
                str.Append("nil");
            }
            else
            {
                int x = ar[i - 1], min = i;

                // II) Find the smallest digit on right
                // side of (i-1)'th digit that is greater
                // than number[i-1]
                for (int j = i + 1; j < n; j++)
                {
                    if (ar[j] > x && ar[j] < ar[min])
                    {
                        min = j;
                    }
                }

                // III) Swap the above found smallest
                // digit with number[i-1]
                swap(ar, i - 1, min);

                // IV) Sort the digits after (i-1)
                // in ascending order
                Array.Sort(ar, i, n - i);
                
                for (i = 0; i < n; i++)
                    str.Append(ar[i]);
            }

            return str.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MathExtension.NextBiggerNumber(111));
        }
    }
}
