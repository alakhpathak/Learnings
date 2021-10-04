using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindow
{
    public static class FixedWindow
    {
        public static int MaximumSumOfKIntegerSolve()
        {
            return MaximumSumOfKInteger(new int[] { 2, 5, 1, 8, 2, 9, 1 }, 3);
        }

        public static int MaximumSumOfKInteger(int[] arr, int k)
        {
            int i = 0, j = 0, sum = 0, maxSum = 0;
            int n = arr.Length;

            while (j < n)
            {
                sum += arr[j];
                if (j - i + 1 < k)
                {
                    j++;
                }
                else if (j - i + 1 == k)
                {
                    maxSum = Math.Max(maxSum, sum);
                    sum -= arr[i];
                    i++;
                    j++;
                }
            }
            return maxSum;
        }
        public static int StringCompressionIISolve()
        {
            return StringCompressionII("aaabcccd", 2);
        }
        private static int StringCompressionII(string s, int k)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int freq;
            int totalCount = s.Length;
            foreach (var item in s)
            {
                if (dict.TryGetValue(item, out freq))
                {
                    dict[item] = dict[item] + 1;
                }
                else
                {
                    dict[item] = 1;
                }
            }
            Console.WriteLine($"totalCount {totalCount}");
            int i = 0;
            int j = 0;
            int n = s.Length;
            int minUnique = s.Length;
            int compressionLength = 0;
            while (j < n)
            {
                // if(j-i+1<k)
                {
                    dict[s[j]]--;
                    if (dict[s[j]] == 0)
                    {
                        dict.Remove(s[j]);
                    }
                    totalCount--;
                    Console.WriteLine($"totalCountSub {totalCount}");
                }

                if (j - i + 1 == k)
                {
                    minUnique = Math.Min(minUnique, dict.Count);
                }
                else if (j - i + 1 > k)
                {
                    if (dict.TryGetValue(s[i], out freq))
                    {
                        dict[s[i]]++;
                    }
                    else
                    {
                        dict[s[i]] = 1;
                    }
                    totalCount++;
                    Console.WriteLine($"totalCountAdd {totalCount}");
                    i++;
                }
                j++;
            }
            Console.WriteLine($"totalCount {totalCount}");
            return totalCount;
        }
    }
}
