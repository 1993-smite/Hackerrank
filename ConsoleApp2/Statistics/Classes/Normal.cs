using Integral;
using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes
{
    public class Normal
    {
        public static double Ro(double x, double m, double q)
        {
            return (1 / (q * Math.Sqrt(2 * Math.PI))) 
                * Math.Pow(Math.E, -Math.Pow(x-m,2)
                / (2 * Math.Pow(q,2)));
        }

        public double M { get; private set; }
        public double Q { get; private set; }

        public Normal(double m, double q)
        {
            M = m;
            Q = q;
        }

        private double RoX(double x)
        {
            return Normal.Ro(x, M, Q);
        }

        public double Fx(double x)
        {
            var integration = new RectangleIntegration();
            return integration.IntegrationBy(-10e3, 0.001, x, RoX);
        }

        public double Ferfx(double x)
        {
            return 0.5 * (1 + erf((x - M) / (Q * (Math.Pow(2,0.5)))));
        }

        public static double erf(double z)
        {
            double t = 1.0 / (1.0 + 0.5 * Math.Abs(z));

            // use Horner's method
            double ans = 1 - t * Math.Exp(-z * z - 1.26551223 +
                                                t * (1.00002368 +
                                                t * (0.37409196 +
                                                t * (0.09678418 +
                                                t * (-0.18628806 +
                                                t * (0.27886807 +
                                                t * (-1.13520398 +
                                                t * (1.48851587 +
                                                t * (-0.82215223 +
                                                t * (0.17087277))))))))));
            if (z >= 0) return ans;
            else return -ans;
        }

    }
}
