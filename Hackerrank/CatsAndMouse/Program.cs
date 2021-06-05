using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsAndMouse
{
    class Program
    {
        public static long taskOfPairing(List<long> freq)
        {
            long count = 0;
            long df = 0;
            for (int i = 0; i < freq.Count; i++)
            {
                count += (freq[i] + df) / 2;
                df = freq[i] % 2;
            }

            return count;
        }

        // Complete the catAndMouse function below.
        static string catAndMouse(int x, int y, int z)
        {
            var diffXZ = Math.Abs(x - z);
            var diffYZ = Math.Abs(y - z);

            var res = "Mouse C";

            if (diffXZ < diffYZ)
                res = "Cat A";
            else if (diffYZ < diffXZ)
                res = "Cat B";
            else
                res = "Mouse C";

            return res;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(catAndMouse(1, 2, 3));
            Console.WriteLine(catAndMouse(1, 3, 2));
            Console.ReadLine();
        }
    }
}
