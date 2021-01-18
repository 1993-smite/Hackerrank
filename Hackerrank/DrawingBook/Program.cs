using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingBook
{
    class Program
    {
        /*
         * Complete the pageCount function below.
         */
        static int pageCount(int n, int p)
        {
            int count = 0;
            var book = new List<Tuple<int, int>>();

            for (int i = 0; i <= n; i+=2)
                book.Add(new Tuple<int, int>(i, i + 1));

            for(int i=0; i < book.Count; i++)
            {
                if (book[i].Item1 == p || book[i].Item2 == p)
                {
                    count = i;
                    break;
                }
            }

            for (int i = book.Count - 1; i > 0; i--)
            {
                if (book[i].Item1 == p || book[i].Item2 == p)
                {
                    if (book.Count - i < count)
                        count = book.Count - i - 1;
                    break;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            var res = pageCount(5,4);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
