using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop
{
    class Program
    {
        /*
         * Complete the getMoneySpent function below.
         */
        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int money = 0;
            int maxMoney = -1;

            for(int i = 0; i < keyboards.Length; i++)
            {
                for(int j = 0; j < drives.Length; j++)
                {
                    money = keyboards[i] + drives[j];
                    if (money > maxMoney && money <= b)
                        maxMoney = money;
                }
            }
            return maxMoney;
        }

        static void Main(string[] args)
        {
            string input = "4";
            var keyboards = input.Split(' ').Select(x => int.Parse(x)).ToArray();

            input = "5";
            var drives = input.Split(' ').Select(x => int.Parse(x)).ToArray();

            int b = 5;
            var res = getMoneySpent(keyboards, drives, b);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
