using System;
using System.Collections.Generic;

namespace Snails
{
    class Program
    {
        public enum Sides
        {
            Right,
            Left,
            Up,
            Down
        }

        public static int[] Snail(int[][] array)
        {
            var result = new List<int>();
            Sides mode = Sides.Right;

            var imin = 0;
            var imax = array.Length - 1;
            var jmin = 0;
            var jmax = array[0].Length - 1;

            var i = imin;
            var j = jmin;
            var done = false;

            while (!done)
            {

                switch (mode)
                {
                    case Sides.Right:
                        i = imin;
                        j = jmin;
                        for (; j <= jmax; j++)
                            result.Add(array[i][j]);
                        mode = Sides.Down;
                        imin++;
                        break;
                    case Sides.Left:
                        i = imax;
                        j = jmax;
                        for (; j >= jmin; j--)
                            result.Add(array[i][j]);
                        mode = Sides.Up;
                        imax--;
                        break;
                    case Sides.Down:
                        i = imin;
                        j = jmax;
                        for (; i <= imax; i++)
                            result.Add(array[i][j]);
                        mode = Sides.Left;
                        jmax--;
                        break;
                    case Sides.Up:
                        i = imax;
                        j = jmin;
                        for (; i >= imin; i--)
                            result.Add(array[i][j]);
                        mode = Sides.Right;
                        jmin++;
                        break;
                }

                if (imin > imax || jmin > jmax)
                    done = true;
            }

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            int[][] array = {
                new []{1, 2, 3, 4},
                new []{5, 6, 7, 8},
                new []{9, 10, 11, 12},
                new []{13, 14, 15, 16}
            };

            Console.WriteLine(string.Join(',',Snail(array)));

            Console.WriteLine("Hello World!");
        }
    }
}
