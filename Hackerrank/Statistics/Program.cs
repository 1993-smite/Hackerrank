using Statistics.Classes;
using Statistics.Classes.MNK;
using System;
using System.Collections.Generic;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "0.18 0.89 109.85;" +
                "1.0 0.26 155.72;" +
                "0.92 0.11 137.66;" +
                "0.07 0.37 76.17;" +
                "0.85 0.16 139.75;" +
                "0.99 0.41 162.6;" +
                "0.87 0.47 151.77";



            int count = 7;

            decimal[][] x = new decimal[count][];
            decimal[][] y = new decimal[count][];

            string[] arr = input.Split(';');

            for (int i = 0; i < count; i++)
            {
                x[i] = new decimal[3];
                y[i] = new decimal[1];
                var line = arr[i].Replace('.', ',').Split(' ');
                x[i][0] = 1;
                x[i][1] = decimal.Parse(line[0]);
                x[i][2] = decimal.Parse(line[1]);
                y[i][0] = decimal.Parse(line[2]);
            }

            /* Calculate B */
            decimal[][] xt = Matrix.transpose(x);
            decimal[][] xtx = Matrix.multiply(xt, x);
            decimal[][] xtxInv = Matrix.invert(xtx);
            decimal[][] xty = Matrix.multiply(xt, y);
            decimal[][] B = Matrix.multiply(xtxInv, xty);

            string str = "0.49 0.18;" +
                "0.57 0.83;" +
                "0.56 0.64;" +
                "0.76 0.18";

            var fff = str.Split(';');
            for (int i = 0; i < fff.Length; i++)
            {
                var line = arr[i].Replace('.', ',').Split(' ');
                decimal b1 = decimal.Parse(line[0]);
                decimal b2 = decimal.Parse(line[1]);


                var res = B[0][0] + B[1][0] * b1 + B[2][0] * b2;
                Console.WriteLine(res);
            }


            //Console.WriteLine("{0:0.000}", );
            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }
}
