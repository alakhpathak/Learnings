using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class SubSetSum
    {
        public bool Solve(int[] arr, int sum)
        {
            bool[,] dp = new bool[sum + 1, arr.Length + 1];
            for (int i = 0; i < sum + 1; i++)
            {
                for (int j = 0; j < arr.Length + 1; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = true;
                    }
                    else if (j == 0 && i != 0)
                    {
                        dp[i, j] = false;
                    }
                    else if (arr[j - 1] > i)
                    {
                        dp[i, j] = dp[i, j - 1];
                    }
                    else
                    {
                        var including = dp[i - arr[j - 1], j - 1];
                        var excluding = dp[i, j - 1];
                        dp[i, j] = including || excluding;
                    }
                }
            }
            return dp[sum, arr.Length];
        }
    }
}
