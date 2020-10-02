using System;

namespace Integral
{
    public delegate double Fx(double x);

    public class RectangleIntegration
    {
        public static double Integration(double from, double h, double to, Fx f)
        {
            double res = 0;
            long count = 0;
            for(double x = from; x < to; x += h)
            {
                count++;
                res += f(x);
            }
            res *= (to - from) / count;
            return res;
        }


        public delegate double FxBy(double x);
        public double IntegrationBy(double from, double h, double to, FxBy f)
        {
            double res = 0;
            long count = 0;
            for (double x = from; x < to; x += h)
            {
                count++;
                res += f(x);
            }
            res *= (to - from) / count;
            return res;
        }
    }
}
