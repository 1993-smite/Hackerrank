using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratoryBirds
{
    class Program
    {
        // Complete the migratoryBirds function below.
        static int migratoryBirds(List<int> arr)
        {
            int result = 0;
            int max = 1;
            var birds = new SortedList<int?, int>();
            for(int i = 0; i < arr.Count; i++)
            {
                var el = arr[i];
                if (birds.Keys.FirstOrDefault(x=>x == el) == null)
                {
                    birds.Add(el, 1);
                }
                else
                {
                    birds[el]++;

                    if (result > el && birds[el] == max)
                    {
                        result = el;
                    }

                    if (birds[el] > max)
                    {
                        max = birds[el];
                        result = el;
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            string input = "1 2 3 4 5 4 3 2 1 3 4";
            var arr = input.Split(' ').Select(x => int.Parse(x)).ToList();
            var res = migratoryBirds(arr);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
