using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.Classes
{
    public class SortedList
    {
        public List<double> List = new List<double>();
        
        public void Add(double item)
        {
            var moreThanItem = List.FindIndex(x=>x > item);
            if (moreThanItem == -1 && List.Count > 0)
            {
                if (List[List.Count - 1] < item)
                {
                    List.Add(item);
                    return;
                }
            }
            List.Insert(Math.Max(moreThanItem, 0), item);
            
        }

        public double this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }

    }

    public class RangeStats
    {
        private long[] _range;

        public double Mean { private set; get;}
        public long Mode { private set; get; }
        public double Median { private set; get; }

        public RangeStats(long[] range)
        {
            _range = range;
            Prepare();
        }

        private void Prepare()
        {
            Dictionary<long, long> repeat = new Dictionary<long, long>();
            long countRepeat = 0;
            long minRepeat = long.MaxValue;

            double mx = 0;


            var sl = new SortedList();

            foreach (var item in _range)
            {
                if (!repeat.ContainsKey(item))
                {
                    repeat.Add(item, 0);
                }
                repeat[item]++;

                if (repeat[item] >= countRepeat)
                {
                    if (repeat[item] == countRepeat && item < minRepeat)
                    {
                        minRepeat = item;
                    }
                    else if (repeat[item] > countRepeat)
                    {
                        minRepeat = item;
                    }
                        
                    countRepeat = repeat[item];
                }

                sl.Add(item);

                mx += item;
            }

            Mean = mx / _range.Length;
            Median = (sl[_range.Length / 2 - 1] + sl[_range.Length / 2]) / 2;
            Mode = minRepeat;

        }

    }
}
