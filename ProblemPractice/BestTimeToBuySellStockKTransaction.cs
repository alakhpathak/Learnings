using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemPractice
{
    public static class BestTimeToBuySellStockKTransaction
    {
        public static int RecursiveSolve()
        {
            // one buy and sell=1 transaction
            int result = RecursiveUtil(new int[] { 7, 1, 5, 3, 6, 4 }, 2);
            return result;
        }

        private static int RecursiveUtil(int[] stocks, int k)
        {
            if (stocks == null || stocks.Length == 0 || stocks.Length == 1)
                return 0;
            if (stocks.Length == 2)
                return Math.Max(0, stocks[1] - stocks[0]);

            return Recursive(stocks, stocks.Length, true, 0, k);
        }
        private static int Recursive(int[] stocks, int n, bool canBuy, int pos, int k)
        {
            if (pos >= n || (canBuy && pos == n - 1))
                return 0;
            int profit = 0;

            int skip = Recursive(stocks, n, canBuy, pos + 1, k);
            if (canBuy)
            {
                int buy = Recursive(stocks, n, false, pos + 1, k - 1) - stocks[pos];
                profit = Math.Max(buy, skip);
            }
            else
            {
                int sell = Recursive(stocks, n, true, pos + 1, k) + stocks[pos];
                profit = Math.Max(sell, skip);
            }

            return Math.Max(profit, skip);
        }
    }
}
