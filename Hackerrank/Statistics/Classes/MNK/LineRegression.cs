using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes.MNK
{


    public class LineRegression
    {
        //y = bx + e
        public List<double> X { get; private set; }
        public List<double> Y { get; private set; }

        public LineRegression(List<double> x, List<double> y)
        {
            X = x;
            Y = y;
        }
    }
}
