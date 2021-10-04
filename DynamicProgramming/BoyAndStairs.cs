using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class BoyAndStairs
    {
        public static void NumberOfWays(int remainingSteps, int[] steps, int start, int end, List<int> paths)
        {
            if (start == end)
            {
                Console.WriteLine(string.Join(",", paths));
                return;
            }
            for (int i = 0; i < steps.Length; i++)
            {
                if (remainingSteps >= steps[i])
                {
                    int nextStep = start + steps[i];

                    paths.Add(nextStep);

                    NumberOfWays(remainingSteps - steps[i], steps, nextStep, end, paths);

                    paths.RemoveAt(paths.Count - 1);
                }
            }
        }
    }
}
