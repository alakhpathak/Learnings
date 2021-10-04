using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ProblemPractice
{
    public class Range1 : IComparable<Range>
    {
        public int Start { get; set; }
        public int End { get; set; }

        public char ID { get; set; }

        public int CompareTo(Range obj)
        {
            return this.Start - obj.Start;
        }
    }

    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }

        public char ID { get; set; }
    }
    public static class OverlappingProblem
    {
        public static int MinimumRemoveForNonOverLapping(List<Range> ranges)
        {
            Range range3 = new Range() { Start = 13, End = 21, ID = 'A' };
            ranges.Add(range3);

            Range range2 = new Range() { Start = 7, End = 15, ID = 'B' };
            ranges.Add(range2);

            Range range1 = new Range() { Start = 4, End = 8, ID = 'C' };
            ranges.Add(range1);
            Range range4 = new Range() { Start = 2, End = 5, ID = 'D' };
            ranges.Add(range4);

            int from = 3;
            int to = 20;
            bool canPick = false;
            bool canDrop = false;
            bool isContinous = true;
            int left = 0;
            int right = 1;
            ranges.Sort((x, y) => x.Start - y.Start);

            while (right < ranges.Count)
            {
                if (ranges[right].Start > from)
                {
                    break;
                }
                if (ranges[left].Start >= from)
                {
                    canPick = true;
                }
                if (ranges[left].End <= to)
                {
                    canDrop = true;
                }
                if (canPick && (ranges[left].End < ranges[right].Start))
                {
                    isContinous = false;
                }
            }
            if (canPick && canDrop && isContinous)
            {
                return 1;
            }
            return -1;
        }
    }
}
