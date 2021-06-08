using System;

namespace Abbreviation
{
    class Program
    {
        public static string abbreviation1(string a, string b)
        {
            string min;
            string minInit;
            string max;

            if (a.Length > b.Length) {
                min = b;
                max = a;
            }
            else
            {
                min = a;
                max = b;
            }

            minInit = min;

            int cnt = 0;
            foreach(var ch in max)
            {
                if (char.IsLower(ch))
                {
                    if (min.IndexOf(char.ToUpper(ch)) > -1)
                    {
                        cnt++;
                        min.Replace(char.ToUpper(ch), ' ');
                    }
                }
                else
                {
                    if (min.IndexOf(ch) < 0)
                        return "NO";
                    else
                    {
                        cnt++;
                        min = min.Replace(ch, ' ');
                    }
                        
                }
            }

            return cnt == minInit.Length ? "YES" : "NO";
        }

        static string abbreviation(string a, string b)
        {
            int aLen = a.Length, bLen = b.Length;
            // arr[i][j] = true iff a(0..i-1) can match b(0..j-1)
            bool[,] arr = new bool[aLen + 1, bLen + 1];
            arr[0,0] = true;
            for (int i = 1; i <= aLen; i++)
            {
                arr[i,0] = arr[i - 1,0] && char.IsLower(a[i - 1]);
            }
            for (int i = 1; i <= aLen; i++)
            {
                for (int j = 1; j <= bLen; j++)
                {
                    arr[i,j] = (arr[i - 1,j - 1] && char.ToUpper(a[i - 1]) == b[j - 1]) ||
                    (arr[i - 1,j] && char.IsLower(a[i - 1]));
                }
            }

            return (arr[aLen,bLen]) ? "YES" : "NO";
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(abbreviation("VLKHNlpsrlrvfxftslslrrh", "VLKHN"));
            Console.WriteLine(abbreviation("KXzQ", "K"));
            Console.ReadLine();
        }
    }
}
