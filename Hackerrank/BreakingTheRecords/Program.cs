using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;

namespace BreakingTheRecords
{
    class Program
    {
        // Complete the breakingRecords function below.
        static int[] breakingRecords(int[] scores)
        {
            int[] maxMinScores = { -1, -1 };
            var max = int.MinValue;
            var min = int.MaxValue;

            for(int i = 0; i < scores.Length; i++)
            {
                if (max < scores[i])
                {
                    max = scores[i];
                    maxMinScores[0]++;
                }
                if (min > scores[i])
                {
                    min = scores[i];
                    maxMinScores[1]++;
                }
            }

            return maxMinScores;
        }

        static void Main(string[] args)
        {
            var arr = Common.StrToInt("3 4 21 36 10 28 35 5 24 42").ToArray();
            var res = breakingRecords(arr);

            Console.WriteLine(string.Join(" ",res));
            Console.ReadLine();
        }
    }
}
