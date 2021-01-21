using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleSum
{
    public static class Common
    {
        public static IEnumerable<int> StrToInt(string input)
        {
            return input.Split(' ').Select(x => int.Parse(x)).ToList();
        }
        public static IEnumerable<long> StrToLong(string input)
        {
            return input.Split(' ').Select(x => long.Parse(x)).ToList();
        }
    }

    class Program
    {
        // Complete the triplets function below.
        static long triplets(int[] a, int[] b, int[] c)
        {
            long result = 0;
            var sa = a.Distinct().OrderBy(x => x).ToArray();
            var sb = b.Distinct().OrderBy(x => x).ToArray();
            var sc = c.Distinct().OrderBy(x => x).ToArray();

            int countA = 0;
            int countC = 0;

            for(int j = 0; j < sb.Length; j++)
            {
                var bb = sb[j];

                countA = sa.Length;
                for (int i = 0; i < sa.Length; i++)
                {
                    if (sa[i] > bb)
                    {
                        countA = i;
                        break;
                    }
                }

                countC = sc.Length;
                for (int k = 0; k < sc.Length; k++)
                {
                    if (sc[k] > bb)
                    {
                        countC = k;
                        break;
                    }

                }

                countA = Array.BinarySearch(a, bb);
                if (countA < 0) countA = ~countA;
                else countA++;

                countC = Array.BinarySearch(c, bb);
                if (countC < 0) countC = ~countC;
                else countC++;

                result += countA * countC;
            }

            return result;
        }

        static void Main(string[] args)
        {
            var a = Common.StrToInt("1 3 5 7").ToArray();
            var b = Common.StrToInt("5 7 9").ToArray();
            var c = Common.StrToInt("7 9 11 13").ToArray();
            var res = triplets(a, b, c);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
