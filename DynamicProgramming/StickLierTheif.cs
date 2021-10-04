using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class StickLierTheif
    {
        static int[] memory = new int[5] { -1, -1, -1, -1, -1 };
        public static int MaxProfitRecursion(int[] arr, int n)
        {
            if (n < 0)
            {
                return 0;
            }
            if (memory[n] != -1)
            {
                return memory[n];
            }

            memory[n] = Math.Max(MaxProfitRecursion(arr, n - 1), arr[n] + MaxProfitRecursion(arr, n - 2));
            return memory[n];
        }
        public static int MaxProfit(int[] arr)
        {

            int[] dp = new int[arr.Length];
            dp[0] = arr[0];
            dp[1] = Math.Max(arr[0], arr[1]);
            for (int i = 2; i < arr.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + arr[i]);
            }
            return dp[arr.Length - 1];
        }
    }
}