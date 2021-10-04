using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemPractice
{
    public static class CraneProblem
    {
        public static int Solve()
        {
            return MinimumCrane(new int[] { 4, 2, 5, 7 }, -2, 0);
        }
        public static int MinimumCrane(int[] ranges, int from, int to)
        {
            int min = from;
            int max = from;
            int crane = 0;

            while (max < to)
            {
                for (int i = 0; i < ranges.Length; i++)
                {
                    int from1 = Math.Max(from, i - ranges[i]);
                    int to1 = Math.Min(to, i + ranges[i]);
                    if (from1 <= min && to1 > max)
                    {
                        max = to1;
                    }
                }
                if (min == max) return -1;
                min = max;
                crane++;
            }
            return crane;
        }
    }
}
