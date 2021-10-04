using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemPractice
{
    public class PlantProblem
    {
        public static void Solve(int[] plants, int days, int profit, int[] remainingProfit, List<int> ways)
        {
            if (days == 0)
            {
                ways.Add(profit);
            }
            else
            {
                for (int i = 0; i < plants.Length; i++)
                {
                    if (remainingProfit[i] > 0)
                    {
                        var sold = remainingProfit[i];
                        profit = profit + sold;
                        days = days - 1;
                        remainingProfit[i] = 0;
                        DecreasePlantProfit(remainingProfit);

                        Solve(plants, days, profit, remainingProfit, ways);

                        IncreasePlantProfit(remainingProfit);
                        remainingProfit[i] = sold;
                        days = days + 1;
                        profit = profit - sold;
                    }
                }
            }
        }

        private static void IncreasePlantProfit(int[] plants)
        {
            for (int j = 0; j < plants.Length; j++)
            {
                plants[j] = plants[j] * 2;
            }
        }

        private static void DecreasePlantProfit(int[] plants)
        {
            for (int j = 0; j < plants.Length; j++)
            {
                plants[j] = plants[j] / 2;
            }
        }
    }
}
