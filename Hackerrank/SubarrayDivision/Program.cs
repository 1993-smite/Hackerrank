using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarrayDivision
{
    class Program
    {
        // Complete the birthday function below.
        static int birthday(List<int> s, int d, int m)
        {
            int count = 0;
    
            int summCount = s.Count + 1;
            int[] summ = new int[summCount];
            for (int i=0;i<s.Count;i++)
            {
                summ[i + 1] = summ[i] + s[i];
            }
            for(int k = 0; k < (summCount - m); k++)
            {
                if (summ[k+m] - summ[k] == d)
                {
                    count++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            string input = "1 1 1 1 1 1";
            //"1 2 3 4 10 20 30 40 100 200";
            //"10 100 300 200 1000 20 30";
            var arr = input.Split(' ').Select(x => int.Parse(x)).ToList();
            int m = 2;
            int d = 3;
            var res = birthday(arr, d, m);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
