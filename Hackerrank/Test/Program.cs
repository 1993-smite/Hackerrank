using NUnit.Framework;

using Interval = System.ValueTuple<int, int>;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleSum;
using System.Numerics;

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

        public static IEnumerable<string> FriendOrFoe(string[] names)
        {
            // Good luck!
            return names.Where(x=>x.Length == 4);
        }

        public static string Likes(string[] name)
        {
            string str;
            switch (name.Length)
            {
                case 0: str = "no one likes this"; break;
                case 1: str = $"{name[0]} likes this"; break;
                case 2: str = $"{name[0]} and {name[1]} likes this"; break;
                case 3: str = $"{name[0]}, {name[1]} and {name[2]} likes this"; break;
                default: str = $"{name[0]}, {name[1]} and {name.Length - 2} others likes this"; break;
            }

            return str;
        }

        public static bool ValidParentheses(string input)
        {
            // Your code here
            int counter = 0;
            foreach(var art in input)
            {
                if (art == '(')
                    counter++;
                else if (art == ')')
                    counter--;
                if (counter < 0)
                    return false;

            }

            return counter == 0;
        }

        public static bool IsSumDigPow(long a)
        {
            string ch = a.ToString();
            long sum = 0;
            for(int i=0; i < ch.Length; i++)
            {
                sum += (long)Math.Pow(int.Parse(ch[i].ToString()),i + 1);
            }

            return sum == a;
        }

        public static long[] SumDigPow(long a, long b)
        {
            // your code
            List<long> itms = new List<long>();
            for (var it = a; it <= b; it++)
            {
                if (IsSumDigPow(it))
                    itms.Add(it);
            }
            return itms.ToArray();
        }

        public static string Rgb(int r, int g, int b)
        {
            r = Math.Min(r, 255);
            g = Math.Min(g, 255);
            b = Math.Min(b, 255);
            r = Math.Max(r, 0);
            g = Math.Max(g, 0);
            b = Math.Max(b, 0);

            return $"{r.ToString("X2")}{g.ToString("X2")}{b.ToString("X2")}";
        }

        public static int Test(string numbers)
        {
            //Your code is here...
            int oddCount = 0;
            int oddIndex = 0;
            int noddIndex = 0;

            var nums = numbers.Split(' ');

            for(int i=0; i < nums.Length; i++)
            {
                var ch = nums[i];
                if (int.Parse(ch) % 2 == 0)
                {
                    oddCount++;
                    oddIndex = i;
                }
                else
                    noddIndex = i;
            }

            return oddCount > 1 ? noddIndex + 1 : oddIndex + 1;
        }

        public static ulong[] productFib(ulong prod)
        {
            ulong first = 0;
            ulong last = 1;

            while (first * last < prod)
            {
                var next = last + first;
                first = last;
                last = next;
            }

            return new ulong[] { first, last, prod.Equals(first * last) ? (ulong)1 : 0 };
        }

        public static string High(string s)
        {
            var words = s.Split(' ');

            var maxCount = 0;
            var maxWord = "";

            foreach (var word in words)
            {
                var length = Encoding.ASCII.GetBytes(word).Sum(x=>x) - word.Length * 96;

                if (length > maxCount)
                {
                    maxCount = length;
                    maxWord = word;
                }
            }


            return maxWord;
        }

        public static int SumIntervals((int, int)[] intervals)
        {
            var map = new HashSet<int>();

            foreach (var interval in intervals)
            {
                for(int index = interval.Item1; index < interval.Item2; index++)
                {
                    if (!map.Contains(index))
                        map.Add(index);
                }
            }

            return map.Count();
        }

        public static string WhoIsNext(string[] names, long n)
        {
            // Your code is here :)
            if (n <= names.Length)
                return names[n - 1];

            long p = 0, N = n;
            while (names.Length * Math.Pow(2, p) <= N)
            {
                N -= (long)(names.Length * Math.Pow(2, p));
                ++p;
            }



            var cnt = (int)((N-1) / Math.Pow(2, p));

            return names[cnt];
        }

        public static string WhoIsNext1(string[] names, long n)
        {
            // Your code is here :)
            var numbers = new Queue<string>();
            foreach (var name in names)
                numbers.Enqueue(name);

            for (int i = 1; i < n; i++)
            {
                var first = numbers.Dequeue();
                numbers.Enqueue(first);
                numbers.Enqueue(first);
            }

            return numbers.Peek();
        }

        public static BigInteger perimeter(BigInteger n)
        {
            // your code
            BigInteger first = 0;
            BigInteger last = 1;
            BigInteger sum = 1;
            for(int i = 0; i < n; i++)
            {
                var next = first + last;
                first = last;
                last = next;

                sum += next;
            }

            return sum * 4;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(perimeter(7));
            //Console.WriteLine(WhoIsNext1(names, n));
            Console.ReadLine();
        }
    }
}
