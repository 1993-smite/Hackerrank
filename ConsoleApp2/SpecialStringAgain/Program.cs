using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialStringAgain
{
    public class ArtItem
    {
        public char Art;
        public List<int> Indexes = new List<int>();

        public ArtItem(char art, int index)
        {
            Art = art;
            Indexes.Add(index);
        }

        public void Add(char art, int index)
        {
            if (Art == art)
                Indexes.Add(index);
        }
    }


    class Program
    {
        // Complete the substrCount function below.
        static long substrCount(int n ,string s)
        {
            long retVal = s.Length;

            for (int i = 0; i < s.Length; i++)
            {
                var startChar = s[i];
                int diffCharIdx = -1;
                for (int j = i + 1; j < s.Length; j++)
                {
                    var currChar = s[j];
                    if (startChar == currChar)
                    {
                        if ((diffCharIdx == -1) ||
                           (j - diffCharIdx) == (diffCharIdx - i))
                            retVal++;
                    }
                    else
                    {
                        if (diffCharIdx == -1)
                            diffCharIdx = j;
                        else
                            break;
                    }
                }
            }
            return retVal;
        }


        static void Main(string[] args)
        {
            string s = "aaaa";
            int n = s.Length;
            var res = substrCount(n, s);

            Console.WriteLine(res);
            Console.ReadLine();

        }
    }
}
