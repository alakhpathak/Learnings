using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemPractice
{
    class MeetingRoomSuggestion
    {
        static void MeetingRoomSuggestionSolve()
        {
            IntervalTree root = new IntervalTree();
            root = root.Insert(null, new Interval(new DateTime(2020, 1, 7, 10, 30, 0), new DateTime(2020, 1, 7, 11, 00, 0)));
            root = root.Insert(root, new Interval(new DateTime(2020, 1, 7, 11, 30, 0), new DateTime(2020, 1, 7, 12, 30, 0)));
            root = root.Insert(root, new Interval(new DateTime(2020, 1, 7, 13, 30, 0), new DateTime(2020, 1, 7, 14, 00, 0)));
            root = root.Insert(root, new Interval(new DateTime(2020, 1, 7, 9, 30, 0), new DateTime(2020, 1, 7, 10, 00, 0)));


            var overlapMeeting = root.OverLapSearch(root, new Interval(new DateTime(2020, 1, 7, 10, 45, 0), new DateTime(2020, 1, 7, 10, 59, 0)));
        }
    }
    class Interval
    {
        public DateTime fromDate;
        public DateTime toDate;
        public Interval(DateTime from, DateTime to)
        {
            fromDate = from;
            toDate = to;
        }
    }

    class IntervalTree
    {
        public Interval interval;
        public DateTime max;
        public IntervalTree left;
        public IntervalTree right;

        public IntervalTree GetNewNode(Interval interval)
        {
            IntervalTree t = new IntervalTree();
            t.interval = interval;
            t.left = null;
            t.right = null;
            return t;
        }
        public IntervalTree Insert(IntervalTree root, Interval node)
        {
            if (root == null)
            {
                return GetNewNode(node);
            }

            var low = root.interval.fromDate;
            if (low.CompareTo(node.fromDate) > 0)
            {
                root.left = Insert(root.left, node);
            }
            else
            {
                root.right = Insert(root.right, node);
            }

            if (root.max < node.toDate)
            {
                root.max = node.toDate;
            }
            return root;
        }

        bool IsOverlap(Interval i1, Interval i2)
        {
            if (i1.fromDate <= i2.toDate && i2.fromDate <= i1.toDate)
                return true;
            return false;
        }

        public Interval OverLapSearch(IntervalTree root, Interval node)
        {
            if (root == null)
            {
                return null;
            }

            if (IsOverlap(root.interval, node))
                return root.interval;

            if (root.left != null && root.left.max >= node.fromDate)
            {
                return OverLapSearch(root.left, node);
            }
            return OverLapSearch(root.right, node);
        }
    }
}
