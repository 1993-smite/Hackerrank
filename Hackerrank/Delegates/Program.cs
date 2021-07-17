using System;

namespace Delegates
{
    public delegate void Test();
    public delegate void Test1(string str);

    class Program
    {
        static void T()
        {
            Console.WriteLine("T()");
        }

        static void M()
        {
            Console.WriteLine("M()");
        }

        static void T1(string str)
        {
            Console.WriteLine("T1()");
        }

        static void Main(string[] args)
        {
            var t = new Test(T);
            var m = new Test(M);
            var t1 = new Test1(T1);

            var res = t + t1;

            res();

            Console.ReadLine();
        }
    }
}
