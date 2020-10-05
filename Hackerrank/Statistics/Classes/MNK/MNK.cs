using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes.MNK
{
    public static class ArrayExtension
    {
        public static double Sum(this double[] arr)
        {
            double sum = 0;
            foreach (var it in arr)
                sum += it;
            return sum;
        }
    }

    public class MNK
    {
        public static double B(double[] x, double[] y)
        {
            //X^t * X
            double res = 0;
            foreach (var it in x)
                res += it * it;

            //X^t * Y
            double resH = 0;
            for (int i = 0; i < x.Length; i++)
                resH += x[i] * y[i];

            //(X^t * X)^-1 * X^t * y
            return resH / res;
        }

        public static double[] BA(double[] x, double[] y)
        {
            double[] result = new double[2];

            int n = x.Length;

            //X^t * Y
            double resXY = 0;
            for (int i = 0; i < x.Length; i++)
                resXY += x[i] * y[i];

            double sx = x.Sum();
            double sy = y.Sum();

            double sqx = 0;
            foreach (var it in x)
                sqx += it * it;

            result[1] = (n * resXY - sx * sy) 
                      / (n * sqx - sx * sx);

            result[0] = (sy - result[1] * sx) / n;
            //(X^t * X)^-1 * X^t * y
            return result;
        }
    }
}
