using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes
{
    public class Quartile
    {
        private long[] _range;

        public double[] Value { private set; get; } = new double[3];
        public double Interquartile { private set; get; }

        public Quartile(long[] range)
        {
            Init(range);
        }

        public Quartile(long[] range, long[] w)
        {
            List<long> arr = new List<long>();
            for(int i = 0; i < range.Length; i++)
            {
                for (int count = 0; count < w[i]; count++)
                    arr.Add(range[i]);
            }
            Init(arr.ToArray());
        }

        public void Init(long[] range)
        {
            Array.Sort(range);
            _range = range;
            Prepare();
        }

        private void Prepare()
        {
            Value[1] = CalcQuantile(_range);

            int center = _range.Length / 2;
            bool isEven = _range.Length % 2 == 0;

            long[] lower = new long[center];
            long[] upper = new long[center];

            for(int i = 0; i < _range.Length; i++)
            {
                if (i < center)
                {
                    lower[i] = _range[i];
                }   
                else if (i == center)
                {
                    if (isEven)
                    {
                        upper[i - center] = _range[i];
                    }
                }
                else
                {
                    upper[i - center - (!isEven ? 1 : 0)] = _range[i];
                }
            }
            Value[0] = CalcQuantile(lower);
            Value[2] = CalcQuantile(upper);

            Interquartile = Value[2] - Value[0];
        }

        private double CalcQuantile(long[] range)
        {
            double res = -1;
            int centerIndex = range.Length / 2;
            if (range.Length % 2 == 1)
            {
                res = range[centerIndex];
            }
            else
            {
                res = (range[centerIndex - 1] + range[centerIndex]) / 2;
            }
            return res;
        }

        public double this[int index]
        {
            get
            {
                return Value[index];
            }
            set
            {
                
            }
        }

    }
}
