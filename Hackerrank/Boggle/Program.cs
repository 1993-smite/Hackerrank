using System;

namespace Boggle
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[][] board =
            //{
            //    new []{'I','L','A','W'},
            //    new []{'B','N','G','E'},
            //    new []{ 'I', 'U','A','O'},
            //    new []{ 'A', 'S', 'R', 'L' }
            //};

            char[][] board =
           {
               new[] { 'E', 'A', 'R', 'A' },
               new[] { 'N', 'L', 'E', 'C' },
               new[] { 'I', 'A', 'I', 'S' },
               new[] { 'B', 'Y', 'O', 'R' }
           };

            var bg = new Boggle3(board, "ROBES");

            Console.WriteLine(bg.Check());
        }
    }
}
