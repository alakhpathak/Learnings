using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class KnapSack
    {
        public static int SolveKnapSack(int[] weight, int[] profit, int n, int capacity)
        {
            if (n == 0 || capacity == 0)
            {
                return 0;
            }

            if (weight[n - 1] > capacity)
            {
                return SolveKnapSack(weight, profit, n - 1, capacity);
            }
            else
            {
                int includingN = profit[n - 1] + SolveKnapSack(weight, profit, n - 1, capacity - weight[n - 1]);
                int excludingN = SolveKnapSack(weight, profit, n - 1, capacity);
                return Math.Max(includingN, excludingN);
            }
        }

        public static int SolveKnapSackMemoiazation(int[] weight, int[] profit, int n, int capacity)
        {
            int[,] dp = KnapScakTableInitialization(n, capacity);
            return SolveKnapSackMemo(weight, profit, n, capacity, dp);
        }

        public static int SolveKnapSackTabular(int[] weight, int[] profit, int n, int capacity)
        {
            int[,] dp = new int[n + 1, capacity + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < capacity + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (weight[i - 1] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        int includingN = profit[i - 1] + dp[i - 1, j - weight[i - 1]];
                        int excludingN = dp[i - 1, j];
                        dp[i, j] = Math.Max(includingN, excludingN);
                    }
                }
            }
            return dp[n, capacity];
        }
        private static int[,] KnapScakTableInitialization(int n, int capacity)
        {
            int[,] dp = new int[n + 1, capacity + 1];

            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < capacity + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        dp[i, j] = -1;
                    }
                }
            }

            return dp;
        }

        private static int SolveKnapSackMemo(int[] weight, int[] profit, int n, int capacity, int[,] dp)
        {
            if (n == 0 || capacity == 0)
            {
                return 0;
            }
            if (dp[n, capacity] != -1)
                return dp[n, capacity];
            else
            {
                if (weight[n - 1] > capacity)
                {
                    dp[n, capacity] = SolveKnapSackMemo(weight, profit, n - 1, capacity, dp);
                    return dp[n, capacity];
                }
                else
                {
                    int includingN = profit[n - 1] + SolveKnapSackMemo(weight, profit, n - 1, capacity - weight[n - 1], dp);
                    int excludingN = SolveKnapSackMemo(weight, profit, n - 1, capacity, dp);
                    dp[n, capacity] = Math.Max(includingN, excludingN);
                    return dp[n, capacity];
                }
            }
        }


        public static bool SubSetSumExist(int[] arr, int n, int sum)
        {
            if (sum != 0 && n == 0)
                return false;
            if (sum == 0)
                return true;
            if (arr[n - 1] > sum)
                return SubSetSumExist(arr, n - 1, sum);

            bool withN = SubSetSumExist(arr, n - 1, sum - arr[n - 1]);
            bool withOutN = SubSetSumExist(arr, n - 1, sum);
            return withN || withOutN;
        }


        public static bool SubSetSumExistTabular(int[] arr, int n, int sum)
        {
            bool[,] dp = SubSetBooleanTabular(arr, n, sum);
            return dp[n, sum];
        }

        private static bool[,] SubSetBooleanTabular(int[] arr, int n, int sum)
        {
            bool[,] dp = new bool[n + 1, sum + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < sum + 1; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = true;
                    }
                    else if (i == 0 && j != 0)
                    {
                        dp[i, j] = false;
                    }
                    else if (arr[i - 1] <= j)
                    {
                        dp[i, j] = dp[i - 1, j - arr[i - 1]] || dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp;
        }

        public static int CountSubSetSum(int[] arr, int n, int sum)
        {
            int[,] dp = SubSetIntTabular(arr, n, sum);
            return dp[n, sum];
        }

        private static int[,] SubSetIntTabular(int[] arr, int n, int sum)
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
                        dp[i, j] = dp[i - 1, j - arr[i - 1]] + dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp;
        }

        public static bool EqualSumPartition(int[] arr)
        {
            int n = arr.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }
            if (sum % 2 != 0)
            {
                return false;
            }
            else
            {
                sum = sum / 2;
                return SubSetSumExistTabular(arr, sum, n);
            }
        }

        public static int MinimumSubSetDifference(int[] arr)
        {
            int n = arr.Length;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }

            bool[,] dp = SubSetBooleanTabular(arr, n, sum);
            int min = Int32.MaxValue;

            for (int i = 0; i < sum / 2; i++)
            {
                if (dp[n, i])
                {
                    min = Math.Min(min, sum - 2 * i);
                }
            }
            return min;
        }

        public static int CountSubSetDifference(int[] arr, int diff)
        {
            int n = arr.Length;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }

            int sumToCheck = (sum + diff) / 2;
            int[,] dp = SubSetIntTabular(arr, n, sumToCheck);

            return dp[n, sumToCheck];
        }

        public static int TargetSumAfterSignChanging(int[] arr, int sum)
        {
            return CountSubSetDifference(arr, sum);
        }
    }
}