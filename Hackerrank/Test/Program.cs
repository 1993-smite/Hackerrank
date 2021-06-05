using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;

namespace Test
{
    class Program
    {
        public static int maxPairs(List<int> skillLevel, int minDiff)
        {
            int count = 0;

            var sorted = skillLevel.OrderBy(x => x).ToList();
            int minIndexMax = sorted.Count;
            int indexMax = 0;

            for (int i = 0; i < minIndexMax; i++)
            {
                if (sorted[i] == int.MaxValue)
                    continue;

                for (int j = Math.Max(i + 1, indexMax); j < sorted.Count; j++)
                {
                    if (sorted[j] - sorted[i] >= minDiff)
                    {
                        count++;
                        indexMax = j + 1;

                        sorted[i] = sorted[j] = int.MaxValue;

                        if (minIndexMax > indexMax)
                        {
                            minIndexMax = indexMax;
                        }

                        break;
                    }
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            var arr = Common.StrToInt("3 4 5 2 1 1").ToList();
            var res = maxPairs(arr, 3);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
