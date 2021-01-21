using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;

namespace MinimumTimeRequired
{
    class Program
    {
        // Complete the minTime function below.
        static long minTime(long[] machines, long goal)
        {
            long min = 1;
            long max = Math.Min(machines.Max()*goal, long.MaxValue - 1);
            long ans = 1;

            while(max - min > 1)
            {
                long mid = (min + max) / 2;
                long done = 0;
                for(int i = 0; i < machines.Length; i++)
                {
                    done += mid / machines[i];
                    if (done >= goal)
                        break;
                }
                if (done >= goal)
                {
                    max = mid;
                    ans = mid;
                }
                else
                    min = mid;
            }
            return ans;
        }

        static void Main(string[] args)
        {
            var arr = Common.StrToLong("4 5 6").ToArray();
            var goal = 12;
            var res = minTime(arr, goal);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
