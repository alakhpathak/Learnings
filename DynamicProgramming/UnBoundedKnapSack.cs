using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class UnBoundedKnapSack
    {
        public static int CoinChangeMaxWays(int[] coins, int sum)
        {
            int[,] dp = UnboundedKnapSackDP(coins, coins.Length, sum);
            return dp[coins.Length, sum];
        }

        public static int CoinChangeMinCoins(int[] coins, int sum)
        {
            int n = coins.Length;
            int[,] dp = new int[n + 1, sum + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < sum + 1; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = Int32.MaxValue - 1;
                    }
                    else if (i != 0 && j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (coins[i - 1] <= j)
                    {
                        dp[i, j] = Math.Min(dp[i, j - coins[i - 1]] + 1, dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[n, sum];
        }

        private static int[,] UnboundedKnapSackDP(int[] arr, int n, int sum)
        {
            int[,] dp = new int[n + 1, sum + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < sum + 1; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else if (i == 0 && j != 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (arr[i - 1] <= j)
                    {
                        dp[i, j] = dp[i, j - arr[i - 1]] + dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp;
        }

        public static int RodCuttingMaxProfit(int[] length, int[] profit, int rodLength)
        {
            int[,] dp = GetUnboundedKnapSackDP(length, profit, rodLength);
            return dp[rodLength, rodLength];
        }

        private static int[,] GetUnboundedKnapSackDP(int[] length, int[] profit, int n)
        {
            int[,] dp = new int[n + 1, n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        if (length[i - 1] <= j)
                        {
                            dp[i, j] = Math.Max(profit[i - 1] + dp[i, j - length[i - 1]], dp[i - 1, j]);
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }
            }
            return dp;
        }

    }
}