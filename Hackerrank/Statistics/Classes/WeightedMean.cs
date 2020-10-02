using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes
{
    public class WeightedMean
    {
        private long[] _w;
        private long[] _range;

        public double Mean { get; private set; } 

        public WeightedMean(long[] w, long[] range)
        {
            _w = w;
            _range = range;

            double sumW = 0;
            Mean = 0;
            for (int index=0; index < _range.Length; index++)
            {
                sumW += w[index];
                Mean += w[index] * _range[index];
            }
            Mean /= sumW;
        }
    }
}
