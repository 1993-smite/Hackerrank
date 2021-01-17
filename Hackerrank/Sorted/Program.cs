using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorted
{
    class Program
    {

        static int getByIndex(SortedList<int, int> list, int index)
        {
            int curIndex = 0;
            for(int i=0;i<list.Values.Count;i++)
            {
                if (curIndex + list.Values[i] > index)
                {
                    return list.Keys[i];
                }
                curIndex += list.Values[i];
            }
            return 0;
        }

        static void addEl(SortedList<int, int> list, int value)
        {
            var key = list.Keys.FirstOrDefault(x => x == value);

            if (key == 0)
                list.Add(value, 1);
            else
                list[key]++;
        }

        static void remEl(SortedList<int, int> list, int value)
        {
            var key = list.Keys.FirstOrDefault(x => x == value);
            
            if (list[key] == 1)
                list.Remove(key);
            else
                list[key]--;
        }

        // Complete the activityNotifications function below.
        static int activityNotifications(int[] expenditure, int d)
        {
            int result = 0;

            SortedList<int, int> list = new SortedList<int, int>();

            int mr = d / 2;
            int ml = mr;

            if (d % 2 == 0)
                ml++;

            double summ = 0;

            for (long i = 0; i < d - 1; i++)
            {
                addEl(list, expenditure[i]);
            }

            for (long i = d - 1; i < expenditure.Length - 1; i++)
            {
                addEl(list, expenditure[i]);

                long prevIndex = i - d;
                if (prevIndex > -1)
                {
                    remEl(list, expenditure[prevIndex]);
                }

                summ = getByIndex(list,mr) + getByIndex(list, ml);

                if (summ <= expenditure[i + 1])
                {
                    result++;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            string input = "1 2 3 4 4";
            int[] arr = input.Split(' ').Select(x=>int.Parse(x)).ToArray();
            int d = 4;
            var res = activityNotifications(arr,d);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
