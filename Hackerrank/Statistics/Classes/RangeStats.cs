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

        public int GetIndex(double item) {
            return List.FindIndex(x=>x == item);
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
        private double[] _range;
        private SortedList _sortedRange;

        public double Mean { private set; get;}
        public double Mode { private set; get; }
        public double Median { private set; get; }

        public double Dx { private set; get; } = 0;
        public double QDx { private set; get; }

        public RangeStats(double[] range)
        {
            _range = range;
            Prepare();
        }

        private void Prepare()
        {
            Dictionary<double, long> repeat = new Dictionary<double, long>();
            long countRepeat = 0;
            double minRepeat = long.MaxValue;

            double mx = 0;


            _sortedRange = new SortedList();

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

                _sortedRange.Add(item);

                mx += item;
            }

            Mean = mx / _range.Length;
            Median = (_sortedRange[_range.Length / 2 - 1] + _sortedRange[_range.Length / 2]) / 2;
            Mode = minRepeat;

            foreach (var el in _range)
                Dx += Math.Pow(el - Mean, 2);

            Dx /= _range.Length;
            QDx = Math.Sqrt(Dx);

        }

        public double Correlate(RangeStats range)
        {
            double r = 0;
            for(int i=0; i < _range.Length; i++)
            {
                r += (_range[i] - Mean) * (range._range[i] - range.Mean);
            }

            r /= (_range.Length * QDx * range.QDx);

            return r;
        }

        public double SpearmansRankCorrelation(RangeStats range)
        {
            double res = 0;

            long n = _range.Length;

            for (int i = 0; i < n; i++)
            {
                int _r = _sortedRange.GetIndex(_range[i]);
                int r = range._sortedRange.GetIndex(range._range[i]);
                res += Math.Pow(_r - r, 2);
            }



            return 1 - ((6 * res) / (n * (Math.Pow(n,2) - 1)));
        }
    }
}
