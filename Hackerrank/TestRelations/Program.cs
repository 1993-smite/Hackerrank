using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestRelations
{
    public class FlyingObject
    {
        public virtual void S()
        {
            Console.WriteLine($"This is FlyingObject");
        }
    }

    public class Aircraft: FlyingObject
    {
        public override void S()
        {
            Console.WriteLine($"This is Aircraft");
        }
    }

    public class Missile : FlyingObject
    {
        public override void S()
        {
            Console.WriteLine($"This is Missile");
        }
    }

    public class Missile1 : FlyingObject
    {
    }

    class Program
    {
        public static int find_it(int[] seq)
        {
            return seq.FirstOrDefault(it => seq.Count(x=>x == it) % 2 == 1);
        }

        public static string[] SortMe(string[] names)
        {
            return names.OrderBy(x => x).ToArray();
        }

        public static string StripComments1(string text, string[] commentSymbols)
        {
            StringBuilder result = new StringBuilder();

            bool isComment = false;
            foreach(var art in text.Trim())
            {
                if (commentSymbols.FirstOrDefault(x=>x == art.ToString()) == null && !isComment)
                {
                    result.Append(art);
                } 
                else if (art == '\n' && isComment) {
                    result.Append(art);
                    isComment = false;
                }
                else
                {
                    isComment = true;
                }
            }

            return result.ToString();
        }

        public static string StripComments2(string text, string[] commentSymbols)
        {
            StringBuilder result = new StringBuilder();

            foreach (var line in text.Split('\n'))
            {
                var dd = string.Join(string.Empty,line.TakeWhile(x => !commentSymbols.Contains(x.ToString())));
                foreach (var art in line.TakeWhile(x => commentSymbols.Contains(x.ToString())))
                {
                    if (commentSymbols.Contains(art.ToString()))
                        break;
                    result.Append(art);
                }
                result.Append('|');
            }

            return result.ToString();
        }

        public static string StripComments(string text, string[] commentSymbols)
        {
            StringBuilder result = new StringBuilder();

            foreach (var line in text.Split('\n'))
            {
                result.Append(string.Join(string.Empty, line.TakeWhile(x => !commentSymbols.Contains(x.ToString()))).TrimEnd());
                result.Append('\n');
            }

            return result.ToString().TrimEnd('\n');
        }

        public static List<string> SinglePermutations1(string text)
        {
            var a = "aabb".ToCharArray();

            var vars = ShowAllCombinations(a);

            var vv = new HashSet<string>();

            foreach (var v in vars)
            {
                var s = string.Join("", v);

                if (!vv.Contains(s))
                    vv.Add(s);
            }

            return vv.ToList();
        }

        public static List<List<T>> ShowAllCombinations<T>(IList<T> arr, List<List<T>> list = null, List<T> current = null)
        {
            if (list == null) list = new List<List<T>>();
            if (current == null) current = new List<T>();
            if (arr.Count == 0) //если все элементы использованы, выводим на консоль получившуюся строку и возвращаемся
            {
                list.Add(current);
                return list;
            }
            for (int i = 0; i < arr.Count; i++) //в цикле для каждого элемента прибавляем его к итоговой строке, создаем новый список из оставшихся элементов, и вызываем эту же функцию рекурсивно с новыми параметрами.
            {
                List<T> lst = new List<T>(arr);
                lst.RemoveAt(i);
                var newlst = new List<T>(current);
                newlst.Add(arr[i]);
                ShowAllCombinations(lst, list, newlst);
            }
            return list;
        }


        static void Main(string[] args)
        {
            //Console.WriteLine(find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));


            //Console.WriteLine(StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
            //"apples, pears\ngrapes\nbananas"
            var a = "aabb".ToCharArray();
            
            var vars = ShowAllCombinations(a);

            var vv = new HashSet<string>();

            foreach (var v in vars)
            {
                var s = string.Join("", v);

                if (!vv.Contains(s))
                    vv.Add(s);
            }

            //var ff = SinglePermutations("aabb");

            Console.ReadLine();
        }
    }
}
