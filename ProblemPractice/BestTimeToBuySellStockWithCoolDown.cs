using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemPractice
{
    public static class BestTimeToBuySellStockWithCoolDown
    {
        public static int RecursiveSolve()
        {
            // 1 day cool down
            int result = Recursive(new int[] { 1, 2, 3, 4, 5 }, 0, 5, 1);
            return result;
        }
        private static int Recursive(int[] stocks, int currentDay, int n, int coolDown)
        {
            if (currentDay >= n)
                return 0;

            //Now find all the positions where we can sell the stock
            int maxVal = 0;
            for (int i = currentDay + 1; i < n; ++i)
            {
                if (stocks[currentDay] < stocks[i])  //We can try to sell on ith day
                                                     //We have 2 choices
                                                     //1.We can sell the stock at ith day and findMax from (i+2)th day
                                                     //2.We don't sell the stock on ith day
                    maxVal = Math.Max(maxVal, stocks[i] - stocks[currentDay] + Recursive(stocks, i + coolDown + 1, n, coolDown));
            }

            maxVal = Math.Max(maxVal, Recursive(stocks, currentDay + 1, n, coolDown)); //Exclude current element
            return maxVal;
        }
        public static int StateMachineSolve()
        {
            // 1 day cool down
            int result = StateMachineSolve(new int[] { 1, 2, 3, 4, 5 });
            return result;
        }

        private static int StateMachineSolve(int[] stocks)
        {
            int n = stocks.Length;
            if (n <= 1)
                return 0;
            int[] noStock = new int[n];
            int[] inHand = new int[n];
            int[] sold = new int[n];

            noStock[0] = 0;
            inHand[0] = -stocks[0];    //bcoz we have bought a stock and never sold it
            sold[0] = 0;

            for (int i = 1; i < n; ++i)
            {
                noStock[i] = Math.Max(noStock[i - 1], sold[i - 1]);
                inHand[i] = Math.Max(inHand[i - 1], noStock[i - 1] - stocks[i]);
                sold[i] = inHand[i - 1] + stocks[i];
            }
            int result = Math.Max(noStock[n - 1], sold[n - 1]);
            return result;
        }
    }
}
